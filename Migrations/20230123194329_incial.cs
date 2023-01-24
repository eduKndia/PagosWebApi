using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PagosWebApi.Migrations
{
    public partial class incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentEntities",
                columns: table => new
                {
                    PaymentEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentEntities", x => x.PaymentEntityId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentServices",
                columns: table => new
                {
                    PaymentServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PaymentEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentServices", x => x.PaymentServiceId);
                    table.ForeignKey(
                        name: "FK_PaymentServices_PaymentEntities_PaymentEntityId",
                        column: x => x.PaymentEntityId,
                        principalTable: "PaymentEntities",
                        principalColumn: "PaymentEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentEntities",
                columns: new[] { "PaymentEntityId", "Name" },
                values: new object[,]
                {
                    { 1, "Ande" },
                    { 2, "Tigo" },
                    { 3, "Banco Continental" }
                });

            migrationBuilder.InsertData(
                table: "PaymentServices",
                columns: new[] { "PaymentServiceId", "Name", "PaymentEntityId" },
                values: new object[,]
                {
                    { 1, "Pago de factura", 1 },
                    { 2, "Pago de factura Telefonia", 2 },
                    { 3, "Pago de factura Internet", 2 },
                    { 4, "Pago de factura TV", 2 },
                    { 5, "Pago de prestamos", 3 },
                    { 6, "Pago de tarjeta de credito", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentServices_PaymentEntityId",
                table: "PaymentServices",
                column: "PaymentEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentServices");

            migrationBuilder.DropTable(
                name: "PaymentEntities");
        }
    }
}
