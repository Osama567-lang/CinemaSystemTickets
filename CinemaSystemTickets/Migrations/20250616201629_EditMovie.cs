using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSystemTickets.Migrations
{
    /// <inheritdoc />
    public partial class EditMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CinemaID",
                table: "Movies",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaID",
                table: "Movies",
                newName: "IX_Movies_CinemaId");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Movies",
                newName: "CinemaID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                newName: "IX_Movies_CinemaID");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaID",
                table: "Movies",
                column: "CinemaID",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
