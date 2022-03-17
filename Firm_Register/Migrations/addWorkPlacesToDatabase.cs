using Microsoft.EntityFrameworkCore.Migrations;

namespace Firm_Register.Migrations
{
    public partial class addWorkPlacesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "WorkPlaces",
    columns: table => new
    {
        Person_Id = table.Column<int>(type: "int", nullable: false),
        Firm_Id = table.Column<int>(type: "int", nullable: false),
        Role_Id = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_WorkPlaces", x => new { x.Person_Id, x.Firm_Id });
        table.ForeignKey(
            name: "FK_WorkPlaces_Firms_Firm_Id",
            column: x => x.Firm_Id,
            principalTable: "Firms",
            principalColumn: "Firm_ID",
            onDelete: ReferentialAction.Cascade);
        table.ForeignKey(
            name: "FK_WorkPlaces_People_Person_Id",
            column: x => x.Person_Id,
            principalTable: "People",
            principalColumn: "Person_Id",
            onDelete: ReferentialAction.Cascade);
        table.ForeignKey(
            name: "FK_WorkPlace_Roles_Role_Id",
            column: x => x.Role_Id,
            principalTable: "Roles",
            principalColumn: "Role_Id",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateIndex(
                name: "IX_Firms_Region_Id",
                table: "Firms",
                column: "Region_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_Firm_Id",
                table: "WorkPlaces",
                column: "Firm_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkPlaces");
        }
    }
}
