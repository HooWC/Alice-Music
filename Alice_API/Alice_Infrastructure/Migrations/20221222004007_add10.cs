using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alice_Infrastructure.Migrations
{
    public partial class add10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SingerStores",
                columns: table => new
                {
                    SingerStoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingerStores", x => x.SingerStoreID);
                });

            migrationBuilder.CreateTable(
                name: "VideoStores",
                columns: table => new
                {
                    VideoStoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStores", x => x.VideoStoreID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingerStores");

            migrationBuilder.DropTable(
                name: "VideoStores");
        }
    }
}
