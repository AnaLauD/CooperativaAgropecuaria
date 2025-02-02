namespace CooperativaAgropecuaria.web.Models.Entities
{
    public class UsoMaquinaria
    {
        public Guid Id { get; set; }
        public Guid MaquinariaId { get; set; }
        public Guid AgricultorId { get; set; }
        public double HorasUso { get; set; }
        public decimal CostoTotal { get; set; }

        public Maquinaria Maquinaria { get; set; }
        public Agricultor Agricultor { get; set; }
    }
}
