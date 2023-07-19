using webapi.Models;

namespace webapi.Repositories
{
    public interface IMercadoriaRepo
    {
        public string GetByIdMercadoria(int id);
        public string GetMercadoria();
        public string AddMercadoria(Request request);
        public string DeleteMercadoria(int id);
        public string UpdateMercadoria(Request request);        
    }
}
