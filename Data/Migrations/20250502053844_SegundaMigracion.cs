using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pc_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_aoptantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_aoptantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Edad = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_mascotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_adopciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMascota = table.Column<int>(type: "INTEGER", nullable: false),
                    MascotaId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAdoptante = table.Column<int>(type: "INTEGER", nullable: false),
                    AdoptanteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_adopciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_adopciones_t_aoptantes_AdoptanteId",
                        column: x => x.AdoptanteId,
                        principalTable: "t_aoptantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_adopciones_t_mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "t_mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_adopciones_AdoptanteId",
                table: "t_adopciones",
                column: "AdoptanteId");

            migrationBuilder.CreateIndex(
                name: "IX_t_adopciones_MascotaId",
                table: "t_adopciones",
                column: "MascotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_adopciones");

            migrationBuilder.DropTable(
                name: "t_aoptantes");

            migrationBuilder.DropTable(
                name: "t_mascotas");
        }
    }
}
