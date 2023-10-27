using System.ComponentModel.DataAnnotations;

namespace API_ProyectoProg1.Models
{
    public class Distribuidor 
    {
        [Key]
        public int IdDistribuidor { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Marca { get; set; }
        [Required]
        public string Contacto { get; set; }
        public int NumeroCompra { get; set; }
    }
}
