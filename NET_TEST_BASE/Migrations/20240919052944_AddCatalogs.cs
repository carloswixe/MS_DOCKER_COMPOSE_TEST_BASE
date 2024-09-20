using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_TEST_BASE.Migrations
{
    /// <inheritdoc />
    public partial class AddCatalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla de QuienRealizaPago
            migrationBuilder.CreateTable(
                name: "ordenante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenante", x => x.Id);
                });

            // Crear la tabla de AQuienSeLePaga
            migrationBuilder.CreateTable(
                name: "beneficiario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficiario", x => x.Id);
                });

            // Modificar la tabla Pago para agregar las claves foráneas
            migrationBuilder.AddColumn<int>(
                name: "OrdenanteId",
                table: "Pagos",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarioId",
                table: "Pagos",
                nullable: false);

            // Crear índices y claves foráneas
            migrationBuilder.CreateIndex(
                name: "IX_Pago_OrdenanteId",
                table: "Pagos",
                column: "OrdenanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_BeneficiarioId",
                table: "Pagos",
                column: "BeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_ordenante_OrdenanteId",
                table: "Pagos",
                column: "OrdenanteId",
                principalTable: "ordenante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_beneficiario_BeneficiarioId",
                table: "Pagos",
                column: "BeneficiarioId",
                principalTable: "beneficiario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_ordenante_OrdenanteId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_beneficiario_BeneficiarioId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pago_OrdenanteId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pago_BeneficiarioId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "OrdenanteId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "BeneficiarioId",
                table: "Pagos");

            migrationBuilder.DropTable(
                name: "ordenante");

            migrationBuilder.DropTable(
                name: "beneficiario");
        }
    }

}
