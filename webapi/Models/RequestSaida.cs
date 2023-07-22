using Newtonsoft.Json;

namespace webapi.Models
{
    public class RequestSaida
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataSaida { get; set; }
        public string Local { get; set; }
    }
}
