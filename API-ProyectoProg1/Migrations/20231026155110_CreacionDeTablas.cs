using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_ProyectoProg1.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distribuidor",
                columns: table => new
                {
                    IdDistribuidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCompra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidor", x => x.IdDistribuidor);
                });

            migrationBuilder.CreateTable(
                name: "Ropa",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PrecioDocena = table.Column<double>(type: "float", nullable: false),
                    PrecioVentaUnid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ropa", x => x.Codigo);
                });

            migrationBuilder.InsertData(
                table: "Distribuidor",
                columns: new[] { "IdDistribuidor", "Contacto", "Marca", "Nombre", "NumeroCompra" },
                values: new object[,]
                {
                    { 1234, "0987654321", "Roland", "Calzoncillos 1", 12 },
                    { 4567, "0987654321", "Roland", "Calzoncillos 1", 12 },
                    { 7890, "0987654321", "Roland", "Calzoncillos 1", 12 }
                });

            migrationBuilder.InsertData(
                table: "Ropa",
                columns: new[] { "Codigo", "Marca", "Nombre", "PrecioDocena", "PrecioVentaUnid", "Stock", "Tipo" },
                values: new object[,]
                {
                    { "1234", "Roland", "Calzoncillos 1", 78.0, 6.5, 12, "Ropa Interior" },
                    { "4567RP", "Marca 2", "Producto 2", 20.539999999999999, 2.25, 4, "Medias" },
                    { "7890RP", "Marca 3", "Producto 3", 35.0, 5.75, 10, "Ropa Interior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distribuidor");

            migrationBuilder.DropTable(
                name: "Ropa");
        }
    }
}
