using Newtonsoft.Json;
using webapi.Context;
using webapi.Models;
using webapi.Request;

namespace webapi.Repositories
{
    public class MercadoriaRepo : IMercadoriaRepo
    {
        private MercadoriaContext _context;
        public MercadoriaRepo(MercadoriaContext context)
        {
            _context = context;
        }
        public string GetEntrada()
        {
            try
            {
                var result = (from mercadoria in _context.Mercadorias
                              join entrada in _context.Entradas on mercadoria.Id equals entrada.Id
                              select new
                              {
                                  entrada.Id,
                                  entrada.Quantidade,
                                  entrada.DataHora,
                                  entrada.Local,
                                  mercadoria.Nome,
                                  mercadoria.Fabricante,
                                  mercadoria.Descricao,
                                  mercadoria.NumeroRegistro,
                                  mercadoria.Tipo

                              }).ToList();
                return JsonConvert.SerializeObject(result);
            }
            catch(Exception ex)
            {
                
                return "Não foi possível retornar o dado solicitado" + ex.Message;
            }   
        }
        public string GetEntradaById(int id)
        {
            try
            {
                var result = (from mercadoria in _context.Mercadorias.Where(x => x.Id == id)
                              join entrada in _context.Entradas on mercadoria.Id equals entrada.Id
                              select new
                              {
                                  entrada.Id,
                                  entrada.Quantidade,
                                  entrada.DataHora,
                                  entrada.Local,
                                  mercadoria.Nome,
                                  mercadoria.Fabricante,
                                  mercadoria.Descricao,
                                  mercadoria.NumeroRegistro,
                                  mercadoria.Tipo

                              }).ToList();

                return JsonConvert.SerializeObject(result);

            }
            catch (Exception ex)
            {

                return "Não foi possível retornar o dado solicitado" + ex.Message;
            }

        }
        public string GetSaida()
        {
            try
            {
                var result = (from mercadoria in _context.Mercadorias
                              join saida in _context.Saidas on mercadoria.Id equals saida.Id
                              select new
                              {
                                  saida.Id,
                                  saida.Quantidade,
                                  saida.DataHora,
                                  saida.Local,
                                  mercadoria.Nome,
                                  mercadoria.Fabricante,
                                  mercadoria.Descricao,
                                  mercadoria.NumeroRegistro,
                                  mercadoria.Tipo

                              }).ToList();

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {

                return "Não foi possível retornar o dado solicitado" + ex.Message;
            }
        }
        public string GetSaidaById(int id)
        {
            try
            {
                var result = (from mercadoria in _context.Mercadorias.Where(x => x.Id == id)
                              join saida in _context.Saidas on mercadoria.Id equals saida.Id
                              select new
                              {
                                  saida.Id,
                                  saida.Quantidade,
                                  saida.DataHora,
                                  saida.Local,
                                  mercadoria.Nome,
                                  mercadoria.Fabricante,
                                  mercadoria.Descricao,
                                  mercadoria.NumeroRegistro,
                                  mercadoria.Tipo

                              }).ToList();

                return JsonConvert.SerializeObject(result);

            }
            catch (Exception ex)
            {
                return "Não foi possível retornar o dado solicitado" + ex.Message;
            }            
        }
        public string AddEntrada(EntradaRequest request)
        {            
            try
            {
                var mercadorias = _context.Entradas.Find(request.Id);
               
                Entrada entrada;
                Mercadoria mercadoria;
               
                mercadoria = new Mercadoria
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    Fabricante = request.Fabricante,
                    NumeroRegistro = request.NumeroRegistro,
                    Tipo = request.Tipo                    
                };

                entrada = new Entrada
                {
                    DataHora = request.DataHora,
                    Local = request.Local,
                    Quantidade = request.Quantidade,
                    Mercadoria = mercadoria
                };

                 _context.Entradas.Add(entrada);
                 _context.SaveChanges();
                return "Mercadoria adicionada com sucesso!";
            }
            catch (Exception ex)
            {
                return "Não foi possível incluir" + ex.Message;
            }
        }
        public string AddSaida(SaidaRequest request)
        {                            
            
            // request.id é o id da mercadoria que precisa registrar a saida           

            try
            {                               
                var mercadoria = _context.Mercadorias.Find(request.Id);
                var entrada = _context.Entradas.FirstOrDefault(x => x.MercadoriaId == request.Id);                
                
                Saida saida;

                saida = new Saida
                {
                    DataHora = request.DataHora,
                    Local = request.Local,
                    Quantidade = request.Quantidade,
                    Mercadoria = mercadoria
                };

                if (entrada.Quantidade >= saida.Quantidade)
                {
                    entrada.Quantidade = entrada.Quantidade - saida.Quantidade;

                    if (entrada.Quantidade < saida.Quantidade)
                    {
                        return "A quantidade de produtos não pode ser menor que a quantidade de saida";
                    }
                }

                _context.Entradas.Update(entrada);
                _context.Saidas.Add(saida);
                _context.SaveChanges();

                return "Saida Registrada com sucesso!";
            }
            catch (Exception ex)
            {
                return "Não foi registrar a saída" + ex.Message;
            }

        }
        public string DeleteMercadoria(int id)
        {
            try
            {
                var mercadoria = _context.Mercadorias.Find(id);
                if (mercadoria == null)
                {
                    return "Não foi possível encontrar o produto";
                }
                _context.Mercadorias.RemoveRange(mercadoria);
                _context.SaveChanges();

                return "Item removido com sucesso!";
            }
            catch(Exception ex)
            {
                return "Ocorreu um erro ao remover o produto" + ex.Message ;
            }
            
        }
        public string UpdateMercadoria(UpdateRequest request)
        {
            if (request == null) return "Preencha os campos adequadamente!";

            var mercadoria = _context.Mercadorias.FirstOrDefault(x => x.Id == request.Id);
            var entrada = _context.Entradas.FirstOrDefault(x => x.MercadoriaId == request.Id);
            var saida = _context.Saidas.FirstOrDefault(x => x.MercadoriaId == request.Id);

            try
            {
                mercadoria.Nome = request.Nome;
                mercadoria.Fabricante = request.Fabricante;
                mercadoria.Descricao = request.Descricao;
                mercadoria.NumeroRegistro = request.NumeroRegistro;
                mercadoria.Tipo = request.Tipo;

                entrada.Local = request.LocalEntrada;
                entrada.Quantidade = request.QuantidadeEntrada;
                entrada.DataHora = request.DataEntrada;

                _context.Mercadorias.Update(mercadoria);                        
                _context.Entradas.Update(entrada);               
                _context.SaveChanges();

                return "Mercadoria Atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro ao tentar atualizar" + ex.Message;
            }
        }        
      
    }
}

