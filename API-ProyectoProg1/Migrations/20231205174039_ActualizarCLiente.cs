using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_ProyectoProg1.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCLiente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.IdComentario);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Cedula", "Apellido", "Contrasenia", "Correo", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { "0987654321", "Apellido2", "contraseña2", "cliente2@example.com", "Dirección2", "Nombre2", "987-654-3210" },
                    { "1234567890", "Apellido1", "contraseña1", "cliente1@example.com", "Dirección1", "Nombre1", "123-456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "IdComentario", "CedulaAutor", "Fecha", "Mensaje", "NombreAutor" },
                values: new object[,]
                {
                    { 1, "1234567890", new DateTime(2023, 12, 5, 12, 40, 39, 291, DateTimeKind.Local).AddTicks(5866), "Este es un comentario de ejemplo 1.", "Nombre del Autor 1" },
                    { 2, "0987654321", new DateTime(2023, 12, 5, 11, 40, 39, 291, DateTimeKind.Local).AddTicks(5883), "Este es un comentario de ejemplo 2.", "Nombre del Autor 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Cedula", "Apellido", "Contraseña", "Correo", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { "0987654321", "Apellido2", "contraseña2", "cliente2@example.com", "Dirección2", "Nombre2", "987-654-3210" },
                    { "1234567890", "Apellido1", "contraseña1", "cliente1@example.com", "Dirección1", "Nombre1", "123-456-7890" }
                });
        }
    }
}
