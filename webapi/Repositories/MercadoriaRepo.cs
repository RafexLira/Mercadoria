using webapi.Context;
using webapi.Models;

namespace webapi.Repositories
{
    public class MercadoriaRepo: IMercadoriaRepo
    {
        private MercadoriaContext _context;
        public MercadoriaRepo(MercadoriaContext context)
        {
            _context = context;
        }
        public Entrada GetByIdMercadoria(Entrada id)
        {
            Entrada Item = null;

            if (_context.Entradas.Contains(id))
            {
                Item = _context.Entradas.Find(id);
            }
            return Item;
        }
        public List<Entrada> GetMercadoria()
        {
            return _context.Entradas.ToList();
        }
        public bool DeleteMercadoria(Entrada id)
        {
            if (_context.Entradas.Contains(id))
            {
                _context.Entradas.RemoveRange(id);
                return true;
            }
            return false;
        }

        public string AddMercadoria(Entrada item)
        {
            var retorno = "Este item já existe";
            if (!_context.Entradas.Contains(item))
            {
                _context.Entradas.Add(item);
            }
            else
            {
                retorno = "Item adicionado com sucesso!";
            }
            return retorno;
        }

        public string UpdateMercadoria(Entrada item)
        {
            var retorno = "Item alterado com sucesso!";
            if (_context.Entradas.Contains(item))
            {
                _context.Entradas.Update(item);
            }
            else
            {
                retorno = "Este Item Não existe";
            }
            return retorno;
        }
    }
}
