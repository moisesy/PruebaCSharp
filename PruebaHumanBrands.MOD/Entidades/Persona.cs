using System.ComponentModel.DataAnnotations;

namespace PruebaHumanBrands.MOD.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El {0} es necesario")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El {0} es necesario")]
        public int CUI { get; set; }
        public int EstadoPersona { get; set; }
    }
}
