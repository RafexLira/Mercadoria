using Newtonsoft.Json;

namespace webapi.Models
{
    public class RequestMercadoria
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroRegistro { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }       
    }
}
