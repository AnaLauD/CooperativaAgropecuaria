using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CooperativaAgropecuaria.web.Models
{
    public class RegistrarUsoMaquinariaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El agricultor es obligatorio.")]
        public Guid AgricultorId { get; set; }

        [Required(ErrorMessage = "La maquinaria es obligatoria.")]
        public Guid MaquinariaId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad de horas.")]
        [Range(0.5, double.MaxValue, ErrorMessage = "Las horas deben ser mayores a 0.")]
        public double HorasUso { get; set; }

        public decimal CostoTotal { get; set; }

        public List<SelectListItem>? Agricultores { get; set; }
        public List<SelectListItem>? Maquinarias { get; set; }
    }

}
