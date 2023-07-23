using webapi.Request;

namespace webapi.Repositories
{
    public interface IMercadoriaRepo
    {
        string AddEntrada(EntradaRequest request);        
        string GetEntrada();
        string GetEntradaById(int id);
        string GetSaida();
        string GetSaidaById(int id);       
        string AddSaida(SaidaRequest request);
        string DeleteMercadoria(int id);
        string UpdateMercadoria(UpdateRequest request);        
    }
}
