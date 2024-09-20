using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_TEST_BASE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AQuienSeLePaga",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "QuienRealizaPago",
                table: "Pagos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
