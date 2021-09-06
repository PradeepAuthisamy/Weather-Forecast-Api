using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.Migrations
{
    public partial class Rims_DeviceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firmware = table.Column<double>(type: "float", nullable: true),
                    Hardware = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RainInfo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sum = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainInfo", x => x.Name);
                    table.ForeignKey(
                        name: "FK_RainInfo_Weather_Name",
                        column: x => x.Name,
                        principalTable: "Weather",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RainInfo");

            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
