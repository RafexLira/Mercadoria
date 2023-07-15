namespace webapi.Models
{
    public class Mercadoria
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string NumeroRegistro { get; set; }
        private string Fabricante { get; set; }
        private string Tipo { get; set; }
        private string Descricao { get; set; }
        public Entrada Entrada { get; set; }
        public Saida Saida { get; set; }
    }
}
