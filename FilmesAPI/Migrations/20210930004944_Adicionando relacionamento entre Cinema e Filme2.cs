using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class AdicionandorelacionamentoentreCinemaeFilme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraDeEncerramento",
                table: "Sessoes",
                newName: "HorarioDeEncerramento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioDeEncerramento",
                table: "Sessoes",
                newName: "HoraDeEncerramento");
        }
    }
}
