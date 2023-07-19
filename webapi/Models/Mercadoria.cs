namespace webapi.Models
{
    public class Mercadoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int EntradaId { get; set; }
        public Entrada Entrada { get; set; }
        public int? SaidaId { get; set; }      
    }
}
