using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherForecast.Handlers
{
    internal class MetosHttpHandler : DelegatingHandler
    {
        private static readonly Uri _apiBaseAddress = new("https://api.fieldclimate.com/v1");
        private static readonly CultureInfo _enUsCulture = new("en-us");

        public MetosHttpHandler(HttpMessageHandler handler)
        {
            base.InnerHandler = handler;
            ApiUri = _apiBaseAddress;
        }

        public Uri ApiUri { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestRoute = request.RequestUri.AbsolutePath;
            string combinedPath = ApiUri.AbsolutePath + requestRoute;
            request.RequestUri = new Uri(ApiUri, combinedPath);

            var requestHttpMethod = request.Method.Method;
            var date = DateTimeOffset.UtcNow;
            request.Headers.Date = date;
            var requestTimeStamp = date.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", _enUsCulture);
            var signatureRawData = $"{requestHttpMethod}{requestRoute}{requestTimeStamp}{PublicKey}";
            var privateKeyByteArray = Encoding.UTF8.GetBytes(PrivateKey);
            var signature = Encoding.UTF8.GetBytes(signatureRawData);
            using (var hmac = new HMACSHA256(privateKeyByteArray))
            {
                var signatureBytes = hmac.ComputeHash(signature);
                var requestSignatureString = ByteArrayToString(signatureBytes);
                request.Headers.Authorization = new AuthenticationHeaderValue("hmac",
                    $"{PublicKey}:{requestSignatureString}");
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        private static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Count() * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}