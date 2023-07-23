using webapi.Models;

namespace webapi.Response
{
    public class MercadoriaResponse
    {
        public List<Saida>? Saidas { get; set; }
        public List<Entrada>? Entradas { get; set; }
        public List<Mercadoria>? Mercadorias { get; set; }
    }
}
