using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class AdicionandorelacionamentoentreCinemaeFilme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessões_Cinemas_CinemaId",
                table: "Sessões");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessões_Filmes_FilmeId",
                table: "Sessões");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessões",
                table: "Sessões");

            migrationBuilder.RenameTable(
                name: "Sessões",
                newName: "Sessoes");

            migrationBuilder.RenameIndex(
                name: "IX_Sessões_FilmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessões_CinemaId",
                table: "Sessoes",
                newName: "IX_Sessoes_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "Sessões");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sessões",
                newName: "IX_Sessões_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sessões",
                newName: "IX_Sessões_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessões",
                table: "Sessões",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessões_Cinemas_CinemaId",
                table: "Sessões",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessões_Filmes_FilmeId",
                table: "Sessões",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
