using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.Migrations
{
    public partial class DeviceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rain7Dayinfo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sum = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rain7Dayinfo", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firmware = table.Column<double>(type: "float", nullable: true),
                    Hardware = table.Column<double>(type: "float", nullable: true),
                    Rain7DayInfoName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Weather_Rain7Dayinfo_Rain7DayInfoName",
                        column: x => x.Rain7DayInfoName,
                        principalTable: "Rain7Dayinfo",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_Rain7DayInfoName",
                table: "Weather",
                column: "Rain7DayInfoName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Rain7Dayinfo");
        }
    }
}