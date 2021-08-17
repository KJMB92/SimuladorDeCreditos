using System.ComponentModel.DataAnnotations;

namespace Credit.Web.Models
{
    public class CreditSimulator
    {
        [Display(Name = "Valor Prestamo")]
        [Required(ErrorMessage = "Se requiere el campo Valor Prestamo")]
        public int ValorPrestamo { get; set; }

        [Display(Name = "Plazo Meses")]
        [Required(ErrorMessage = "Se requiere el campo Plazo Meses")]
        public int PlazoMeses { get; set; }

        [Display(Name = "Tasa Mes Vencida")]
        [Required(ErrorMessage = "Se requiere el campo Tasa Mes Vencida")]
        public double TasaMesVencida { get; set; }

        [Display(Name = "Valor Seguro")]
        [Required(ErrorMessage = "Se requiere el campo Valor Seguro")]
        public int ValorSeguro { get; set; }

        
    }
}