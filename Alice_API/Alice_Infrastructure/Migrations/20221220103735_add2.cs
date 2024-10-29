using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alice_Infrastructure.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Singer",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "SingerImg",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "SongName",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SingerID",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    SingerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingerInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.SingerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Singers");

            migrationBuilder.DropColumn(
                name: "SingerID",
                table: "Musics");

            migrationBuilder.AlterColumn<string>(
                name: "SongName",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Singer",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SingerImg",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
