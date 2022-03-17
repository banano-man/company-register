using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Firm_Register.Migrations
{
    public partial class addFirmsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Firms",
               columns: table => new
               {
                   Firm_ID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   EIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Firm_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Region_Id = table.Column<int>(type: "int", nullable: false),
                   Found_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Capital = table.Column<int>(type: "int", nullable: false),
                   Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Firms", x => x.Firm_ID);
                   table.ForeignKey(
                       name: "FK_Firms_Regions_Region_Id",
                       column: x => x.Region_Id,
                       principalTable: "Regions",
                       principalColumn: "Region_Id",
                       onDelete: ReferentialAction.Cascade);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firms");
        }
    }
}
