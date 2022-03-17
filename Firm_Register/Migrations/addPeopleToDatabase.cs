using Microsoft.EntityFrameworkCore.Migrations;

namespace Firm_Register.Migrations
{
    public partial class addPeopleToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Person_Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Person_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Person_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Person_First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Person_Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Person_EGN = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_People", x => x.Person_Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

        }
    }
}
