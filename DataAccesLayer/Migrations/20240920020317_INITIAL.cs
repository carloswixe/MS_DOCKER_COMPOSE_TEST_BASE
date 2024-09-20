using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadProductos = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenanteId = table.Column<int>(type: "int", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Ordenante_OrdenanteId",
                        column: x => x.OrdenanteId,
                        principalTable: "Ordenante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_BeneficiarioId",
                table: "Pagos",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_OrdenanteId",
                table: "Pagos",
                column: "OrdenanteId");

            migrationBuilder.Sql("USE [PagosDB]\r\nGO\r\n\r\n/****** Object:  Trigger [dbo].[trg_AuditoriaPago]    Script Date: 20/09/2024 01:29:51 p. m. ******/\r\nSET ANSI_NULLS ON\r\nGO\r\n\r\nSET QUOTED_IDENTIFIER ON\r\nGO\r\n\r\ncreate TRIGGER [dbo].[trg_AuditoriaPago]\r\nON [dbo].[Pagos]\r\nAFTER INSERT, UPDATE, DELETE\r\nAS\r\nBEGIN\r\n    DECLARE @Accion NVARCHAR(50)\r\n    DECLARE @Detalles NVARCHAR(MAX)\r\n    DECLARE @Usuario NVARCHAR(100)\r\n\r\n    -- Aquí puedes ajustar la forma en que determinas el usuario\r\n    SET @Usuario = SYSTEM_USER\r\n\r\n    -- Si es un INSERT\r\n    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)\r\n    BEGIN\r\n        SET @Accion = 'Insert'\r\n        SET @Detalles = 'Concepto: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Concepto FROM inserted)), 'null') + ', ' +\r\n                        'CantidadProductos: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT CantidadProductos FROM inserted)), 'null') + ', ' +\r\n                        'OrdenanteId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT OrdenanteId FROM inserted)), 'null') + ', ' +\r\n                        'BeneficiarioId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT BeneficiarioId FROM inserted)), 'null') + ', ' +\r\n                        'MontoTotal: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT MontoTotal FROM inserted)), 'null') + ', ' +\r\n                        'Estatus: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Estatus FROM inserted)), 'null')\r\n\r\n        -- Inserta el registro en la bitácora\r\n        INSERT INTO Bitacoras (Entidad, Accion, Usuario, Detalles,fecha)\r\n        VALUES ('Pago', @Accion, @Usuario, @Detalles,GETDATE())\r\n    END\r\n\r\n    -- Si es un DELETE\r\n    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)\r\n    BEGIN\r\n        SET @Accion = 'Delete'\r\n        SET @Detalles = 'Concepto: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Concepto FROM deleted)), 'null') + ', ' +\r\n                        'CantidadProductos: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT CantidadProductos FROM deleted)), 'null') + ', ' +\r\n                        'OrdenanteId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT OrdenanteId FROM deleted)), 'null') + ', ' +\r\n                        'BeneficiarioId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT BeneficiarioId FROM deleted)), 'null') + ', ' +\r\n                        'MontoTotal: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT MontoTotal FROM deleted)), 'null') + ', ' +\r\n                        'Estatus: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Estatus FROM deleted)), 'null')\r\n\r\n        -- Inserta el registro en la bitácora\r\n        INSERT INTO Bitacoras (Entidad, Accion, Usuario, Detalles,fecha)\r\n        VALUES ('Pago', @Accion, @Usuario, @Detalles,GETDATE())\r\n    END\r\n\r\n    -- Si es un UPDATE\r\n    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)\r\n    BEGIN\r\n        SET @Accion = 'Update'\r\n        SET @Detalles = 'Concepto: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Concepto FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Concepto FROM inserted)), 'null') + ', ' +\r\n                        'CantidadProductos: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT CantidadProductos FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT CantidadProductos FROM inserted)), 'null') + ', ' +\r\n                        'OrdenanteId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT OrdenanteId FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT OrdenanteId FROM inserted)), 'null') + ', ' +\r\n                        'BeneficiarioId: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT BeneficiarioId FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT BeneficiarioId FROM inserted)), 'null') + ', ' +\r\n                        'MontoTotal: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT MontoTotal FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT MontoTotal FROM inserted)), 'null') + ', ' +\r\n                        'Estatus: ' + ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Estatus FROM deleted)), 'null') + ' -> ' + \r\n                        ISNULL(CONVERT(NVARCHAR(MAX), (SELECT Estatus FROM inserted)), 'null')\r\n\r\n        -- Inserta el registro en la bitácora\r\n        INSERT INTO Bitacoras (Entidad, Accion, Usuario, Detalles,fecha)\r\n        VALUES ('Pago', @Accion, @Usuario, @Detalles,GETDATE())\r\n    END\r\nEND\r\nGO\r\n\r\nALTER TABLE [dbo].[Pagos] ENABLE TRIGGER [trg_AuditoriaPago]\r\nGO\r\n\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Beneficiario");

            migrationBuilder.DropTable(
                name: "Ordenante");
        }
    }
}
