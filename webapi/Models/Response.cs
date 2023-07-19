namespace webapi.Models
{
    public class Response
    {
        public string Quantidade { get; set; }
        public DateTime DataEntrada { get; set; }
        public string LocalEntrada { get; set; }
        public Mercadoria Mercadorias { get; set; }

    }
   
}
