using System.ComponentModel.DataAnnotations;

namespace API_ProyectoProg1.Models
{
    public class Cliente
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        [Key]
        public string Cedula { get; set; }

        public string Correo { get; set; }

        public string Contrasenia { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
    }
}
