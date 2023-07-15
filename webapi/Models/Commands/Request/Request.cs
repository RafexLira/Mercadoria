namespace webapi.Models.Commands.Request
{
    public class Request
    {
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string Local { get; set; }

    }
}
