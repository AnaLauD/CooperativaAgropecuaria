using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CooperativaAgropecuaria.web.Models
{
    public class AddMaquinariaViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public decimal CostoHora { get; set; }

        [Required]
      
        public Guid AgricultorId { get; set; }

        public List<SelectListItem> Agricultores { get; set; } = new List<SelectListItem>();
    }
}
