using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleSongbook.Migrations
{
    /// <inheritdoc />
    public partial class DBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lyrics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chords = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongID", "Chords", "Lyrics", "Title" },
                values: new object[,]
                {
                    { 1, "C a F G\n C a F G\n C a F G", "Cześć, robię test\nWPF fajny nie jest\nMam już dość go\nprosze zabierzcie go", "Testowa piosenka" },
                    { 2, "nicG\n C a F G\n niiiiiiic", "Cześć, robię nic\nnic fajny jest\nMam już dość go\nprosze zabierzcie go", "Zmęczona piosenka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
