using API_ProyectoProg1.Models;
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
        public DbSet<Ropa> Pedido { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ropa>().HasData(

                new Ropa
                {
                    Codigo = "1234",
                    Nombre = "Calzoncillos 1",
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


        }

       

    }
}
