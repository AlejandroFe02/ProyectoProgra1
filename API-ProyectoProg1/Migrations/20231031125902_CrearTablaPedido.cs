using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ProyectoProg1.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDistribuidor",
                table: "Ropa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDistribuidor = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PrecioDocena = table.Column<double>(type: "float", nullable: false),
                    PrecioVentaUnid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "PedidoId", "IdDistribuidor", "Marca", "Nombre", "PrecioDocena", "PrecioVentaUnid", "Stock", "Tipo" },
                values: new object[] { "70", 7890, "Marca 3", "Producto pedido", 35.0, 5.75, 1, "Ropa Interior" });

            migrationBuilder.UpdateData(
                table: "Ropa",
                keyColumn: "Codigo",
                keyValue: "1234",
                column: "IdDistribuidor",
                value: 1234);

            migrationBuilder.UpdateData(
                table: "Ropa",
                keyColumn: "Codigo",
                keyValue: "4567RP",
                column: "IdDistribuidor",
                value: 4567);

            migrationBuilder.UpdateData(
                table: "Ropa",
                keyColumn: "Codigo",
                keyValue: "7890RP",
                column: "IdDistribuidor",
                value: 7890);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdDistribuidor",
                table: "Ropa");
        }
    }
}
