using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    Furnishing = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    TotalFloors = table.Column<int>(type: "int", nullable: true),
                    SpecialFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availibility = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyAge = table.Column<double>(type: "float", nullable: true),
                    IsGate = table.Column<bool>(type: "bit", nullable: true),
                    MainEntrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPropertyArea = table.Column<double>(type: "float", nullable: false),
                    BuiltArea = table.Column<double>(type: "float", nullable: true),
                    CarpetArea = table.Column<double>(type: "float", nullable: true),
                    CarParking = table.Column<int>(type: "int", nullable: true),
                    CommercialUse = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
