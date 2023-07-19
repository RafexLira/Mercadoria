namespace webapi.Models
{
    public class Entrada
    {        
        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public string? Local { get; set; }
        public Mercadoria? Mercadorias { get; set; }     

    }
}
