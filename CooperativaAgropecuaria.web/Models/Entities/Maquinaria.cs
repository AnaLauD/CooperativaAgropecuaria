namespace CooperativaAgropecuaria.web.Models.Entities
{
    public class Maquinaria
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public decimal CostoHora { get; set; }

        public Guid AgricultorId { get; set; }

        public Agricultor Agricultor { get; set; }
        public ICollection<UsoMaquinaria> UsosMaquinaria { get; set; }
    }
}
