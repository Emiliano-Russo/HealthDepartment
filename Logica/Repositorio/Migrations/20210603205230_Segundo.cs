using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsSuperAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Cancion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<float>(type: "real", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPsicologo = table.Column<int>(type: "int", nullable: false),
                    NombrePsicologo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormatoConsulta = table.Column<int>(type: "int", nullable: false),
                    DireccionConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioFinal = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    DuracionSesionHoras = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Porcentaje = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GaleriaMusical",
                columns: table => new
                {
                    CategoriaMusical = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaleriaMusical", x => x.CategoriaMusical);
                });

            migrationBuilder.CreateTable(
                name: "IX_Cancion_Galeria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCancion = table.Column<int>(type: "int", nullable: false),
                    IDGaleria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Cancion_Galeria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IX_Cancion_PlayList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCancion = table.Column<int>(type: "int", nullable: false),
                    IDPlayList = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Cancion_PlayList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IX_Galeria_PlayList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPlaylist = table.Column<int>(type: "int", nullable: false),
                    IDGaleria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Galeria_PlayList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IX_Psicologo_Dolencia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPsicologo = table.Column<int>(type: "int", nullable: false),
                    IDDolencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Psicologo_Dolencia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IX_Video_Galeria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVideo = table.Column<int>(type: "int", nullable: false),
                    IDGaleria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Video_Galeria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IX_Video_PlayList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVideo = table.Column<int>(type: "int", nullable: false),
                    IDPlayList = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IX_Video_PlayList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Psicologo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormatoConsulta = table.Column<int>(type: "int", nullable: false),
                    DireccionUrbana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioHora = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psicologo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsSuperAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuracionMins = table.Column<int>(type: "int", nullable: false),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Cancion");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Credito");

            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.DropTable(
                name: "GaleriaMusical");

            migrationBuilder.DropTable(
                name: "IX_Cancion_Galeria");

            migrationBuilder.DropTable(
                name: "IX_Cancion_PlayList");

            migrationBuilder.DropTable(
                name: "IX_Galeria_PlayList");

            migrationBuilder.DropTable(
                name: "IX_Psicologo_Dolencia");

            migrationBuilder.DropTable(
                name: "IX_Video_Galeria");

            migrationBuilder.DropTable(
                name: "IX_Video_PlayList");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Psicologo");

            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
