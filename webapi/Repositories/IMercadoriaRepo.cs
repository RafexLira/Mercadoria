using webapi.Models;

namespace webapi.Repositories
{
    public interface IMercadoriaRepo
    {
        public Entrada GetByIdMercadoria(Entrada id);
        public List<Entrada> GetMercadoria();
        public string AddMercadoria(Entrada item);
        public bool DeleteMercadoria(Entrada id);
        public string UpdateMercadoria(Entrada item);
    }
}
