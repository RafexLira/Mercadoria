namespace webapi.Models
{
    public class Entrada
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public int MercadoriaId { get; set; }
        public Mercadoria Mercadoria { get; set; }

    }
}
