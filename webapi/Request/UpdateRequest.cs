using webapi.Models;

namespace webapi.Request
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public int QuantidadeEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public string LocalEntrada { get; set; }
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
