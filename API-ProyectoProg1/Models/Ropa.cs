using System.ComponentModel.DataAnnotations;

namespace API_ProyectoProg1.Models
{
    public class Ropa
    {
        [Key]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdDistribuidor { get; set; }
        [Required]
        public string Marca { get; set; }
        public string Tipo { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public double PrecioDocena { get; set; }
        [Required]
        public double PrecioVentaUnid { get; set; }
    }
}
