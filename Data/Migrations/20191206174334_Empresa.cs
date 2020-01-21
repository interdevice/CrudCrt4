using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudCrt4.Data.Migrations
{
    public partial class Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteudo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Artigo = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    Upload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conteudo");
        }
    }
}
