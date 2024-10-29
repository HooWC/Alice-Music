using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alice_Infrastructure.Migrations
{
    public partial class add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongImg",
                table: "Singers");

            migrationBuilder.AddColumn<int>(
                name: "SingerType",
                table: "Singers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SingerType",
                table: "Singers");

            migrationBuilder.AddColumn<string>(
                name: "SongImg",
                table: "Singers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
