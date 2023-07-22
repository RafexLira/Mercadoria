using webapi.Models;

namespace webapi.Repositories
{
    public interface IMercadoriaRepo
    {
        public string GetByIdEntrada(int id);
        public string GetEntradaMercadoria();
        public string GetByIdSaida(int id);
        public string GetSaidaMercadoria();
        public string AddMercadoria(RequestEntrada request);
        public string DeleteMercadoria(int id);
        public string UpdateMercadoria(RequestMercadoria request);        
        public string AddSaidaMercadoria(RequestSaida request);        
    }
}
