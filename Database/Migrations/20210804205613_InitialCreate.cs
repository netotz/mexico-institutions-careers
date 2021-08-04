using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatGradoCarrera",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGradoCarrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatInstitucion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatInstitucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatCarrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idGrado = table.Column<int>(type: "int", nullable: false),
                    DegreeId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCarrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatCarrera_CatGradoCarrera_DegreeId1",
                        column: x => x.DegreeId1,
                        principalTable: "CatGradoCarrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatRelacionInstitucionCarrera",
                columns: table => new
                {
                    idInstitucion = table.Column<int>(type: "int", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRelacionInstitucionCarrera", x => new { x.idInstitucion, x.idCarrera });
                    table.ForeignKey(
                        name: "FK_CatRelacionInstitucionCarrera_CatCarrera_idCarrera",
                        column: x => x.idCarrera,
                        principalTable: "CatCarrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatRelacionInstitucionCarrera_CatInstitucion_idInstitucion",
                        column: x => x.idInstitucion,
                        principalTable: "CatInstitucion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatCarrera_DegreeId1",
                table: "CatCarrera",
                column: "DegreeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatRelacionInstitucionCarrera_idCarrera",
                table: "CatRelacionInstitucionCarrera",
                column: "idCarrera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatRelacionInstitucionCarrera");

            migrationBuilder.DropTable(
                name: "CatCarrera");

            migrationBuilder.DropTable(
                name: "CatInstitucion");

            migrationBuilder.DropTable(
                name: "CatGradoCarrera");
        }
    }
}
