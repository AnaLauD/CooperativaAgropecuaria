namespace CooperativaAgropecuaria.web.Models.Entities
{
    public class Agricultor
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string TamanoCampo { get; set; }

        public ICollection<Maquinaria> Maquinarias { get; set; }

        public ICollection<UsoMaquinaria> UsosMaquinaria { get; set; }

    }
}
