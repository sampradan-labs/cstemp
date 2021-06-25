using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApis.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Aadhaar = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PersonGender = table.Column<int>(nullable: false),
                    HasHands = table.Column<bool>(nullable: false),
                    HasLegs = table.Column<bool>(nullable: false),
                    HasIQ = table.Column<bool>(nullable: false),
                    HasFace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Aadhaar);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
