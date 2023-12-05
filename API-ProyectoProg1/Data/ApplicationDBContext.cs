﻿using API_ProyectoProg1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoProg1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        public DbSet<Ropa> Ropa { get; set; }
        public DbSet<Distribuidor> Distribuidor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Comentario> Comentario { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ropa>().HasData(

                new Ropa
                {
                    Codigo = "1234",
                    Nombre = "Calzoncillos 1",
                    IdDistribuidor = 1234,
                    Marca = "Roland",
                    Tipo = "Ropa Interior",
                    Stock=12,
                    PrecioDocena=78,
                    PrecioVentaUnid= 6.50 
                },
                new Ropa
                {
                    Codigo = "4567RP",
                    Nombre = "Producto 2",
                    IdDistribuidor = 4567,
                    Marca = "Marca 2",
                    Tipo = "Medias",
                    Stock = 4,
                    PrecioDocena = 20.54,
                    PrecioVentaUnid = 2.25
                },
                new Ropa
                {
                    Codigo = "7890RP",
                    Nombre = "Producto 3",
                    IdDistribuidor = 7890,
                    Marca = "Marca 3",
                    Tipo = "Ropa Interior",
                    Stock = 10,
                    PrecioDocena = 35,
                    PrecioVentaUnid = 5.75
                }
                );



            modelBuilder.Entity<Distribuidor>().HasData(

                new Distribuidor
                {
                    IdDistribuidor = 1234,
                    Nombre = "Calzoncillos 1",
                    Marca = "Roland",
                    Contacto = "0987654321",
                    NumeroCompra= 12
                },
                new Distribuidor
                {
                    IdDistribuidor = 4567,
                    Nombre = "Calzoncillos 1",
                    Marca = "Roland",
                    Contacto = "0987654321",
                    NumeroCompra = 12
                },
                new Distribuidor
                {
                    IdDistribuidor = 7890,
                    Nombre = "Calzoncillos 1",
                    Marca = "Roland",
                    Contacto = "0987654321",
                    NumeroCompra = 12
                }
                );

            modelBuilder.Entity<Pedido>().HasData(
                new Pedido
                {
                    PedidoId = "70",
                    Nombre = "Producto pedido",
                    IdDistribuidor = 7890,
                    Marca = "Marca 3",
                    Tipo = "Ropa Interior",
                    Stock = 1,
                    PrecioDocena = 35,
                    PrecioVentaUnid = 5.75
                }
                );
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Nombre = "Nombre1",
                    Apellido = "Apellido1",
                    Cedula = "1234567890",
                    Correo = "cliente1@example.com",
                    Contrasenia = "contraseña1",
                    Direccion = "Dirección1",
                    Telefono = "123-456-7890"
                },
                new Cliente
                {
                    Nombre = "Nombre2",
                    Apellido = "Apellido2",
                    Cedula = "0987654321",
                    Correo = "cliente2@example.com",
                    Contrasenia = "contraseña2",
                    Direccion = "Dirección2",
                    Telefono = "987-654-3210"
                }
                );
            modelBuilder.Entity<Comentario>().HasData(
                new Comentario
                {
                    IdComentario = 1,
                    CedulaAutor = "1234567890",
                    NombreAutor = "Nombre del Autor 1",
                    Mensaje = "Este es un comentario de ejemplo 1.",
                    Fecha = DateTime.Now
                },
                new Comentario 
                {
                    IdComentario = 2,
                    CedulaAutor = "0987654321",
                    NombreAutor = "Nombre del Autor 2",
                    Mensaje = "Este es un comentario de ejemplo 2.",
                    Fecha = DateTime.Now.AddHours(-1)
                }
                );
        }
    }
}
