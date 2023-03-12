using Microsoft.EntityFrameworkCore.Migrations;

namespace Januar_2021.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeGrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longituda = table.Column<double>(type: "float", nullable: false),
                    Latituda = table.Column<double>(type: "float", nullable: false),
                    SlikaGrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mesec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeMeseca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProsecnaTemp = table.Column<double>(type: "float", nullable: false),
                    KolicinaPadavina = table.Column<double>(type: "float", nullable: false),
                    SuncaniDani = table.Column<int>(type: "int", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mesec_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesec_GradID",
                table: "Mesec",
                column: "GradID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesec");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
