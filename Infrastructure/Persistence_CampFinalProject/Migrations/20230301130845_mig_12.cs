using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence_CampFinalProject.Migrations
{
    public partial class mig_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                column: "ConcurrencyStamp",
                value: "482ddb29-4b2a-414b-8f0a-598fb5740139");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                column: "ConcurrencyStamp",
                value: "e7f108f0-44fb-4f24-a42f-3501dc3ea6b7");
        }
    }
}
