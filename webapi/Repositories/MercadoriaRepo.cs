using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using webapi.Context;
using webapi.Models;
namespace webapi.Repositories
{
    public class MercadoriaRepo : IMercadoriaRepo
    {
        private MercadoriaContext _context;
        private readonly IMapper _mapper;
        public MercadoriaRepo(IMapper mapper, MercadoriaContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public string GetMercadoria()
        {
            //LEMBRETE PESSOAL
            //FALTA ADICIONAR A ENTIDADE SAIDA E CORRIGIR O RETORNO NULL NA JSON

            var mercadoria = _context.Entradas
               .Join(_context.Mercadorias,
                   entrada => entrada.Id,
                    mercadoria => mercadoria.Entrada.Id,
                   (entrada, mercadoria) => new Response
                   {
                       Quantidade = entrada.Quantidade.ToString(),
                       DataEntrada = entrada.DataHora,
                       LocalEntrada = entrada.Local,
                       Mercadorias = entrada.Mercadorias

                   })
            .ToList();

            return JsonConvert.SerializeObject(mercadoria);
        }
        public string GetByIdMercadoria(int id)
        {
            //LEMBRETE PESSOAL
            //FALTA ADICIONAR A ENTIDADE SAIDA E CORRIGIR O RETORNO NULL NA JSON


            if (id == null)
            {
                return "";
            }
           
            var mercadoria = _context.Entradas.Where(x => x.Id == id)
              .Join(_context.Mercadorias,
                  entrada => entrada.Id,
                   mercadoria => mercadoria.Entrada.Id,
                  (entrada, mercadoria) => new Response
                  {
                      Quantidade = entrada.Quantidade.ToString(),
                      DataEntrada = entrada.DataHora,
                      LocalEntrada = entrada.Local,
                      Mercadorias = entrada.Mercadorias
                  });

            return JsonConvert.SerializeObject(mercadoria);
        }

        public string AddMercadoria(Request request)
        {
            try
            {
                var mercadoria = _context.Entradas.Find(request.Id);
                if (mercadoria != null)
                {
                    return "Este produto já existe!";
                }

                Entrada novaEntrada;
                Mercadoria novaMercadoria;

                request.DataHora = DateTime.Now;

                novaMercadoria = new Mercadoria
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    Fabricante = request.Fabricante,
                    NumeroRegistro = request.NumeroRegistro,
                    Tipo = request.Tipo
                };

                novaEntrada = new Entrada { Quantidade = request.Quantidade, Local = request.Local, Mercadorias = novaMercadoria, DataHora = DateTime.Now };

                _context.Entradas.Add(novaEntrada);
                _context.SaveChanges();
               

            }
            catch
            {

            }
            return "Adicionado com sucesso!";
        }

        public string DeleteMercadoria(int id)
        {
        
            try
            {
                var mercadoria = _context.Entradas.Find(id);
                if (mercadoria != null)
                {
                    return "Não foi possível encontrar o produto";
                }
                _context.Entradas.RemoveRange(mercadoria);
                _context.SaveChanges();
            }
            catch
            {

            }
            return "Item removido com sucesso!";
        }

        public string UpdateMercadoria(Request request)
        {
            var entrada = _context.Entradas.Find(request.Id);
            var mercadoria = _context.Mercadorias.FirstOrDefault(x => x.EntradaId == entrada.Id);           
            
            if (mercadoria != null && entrada != null) 
            {               

                entrada.Local = request.Local;
                entrada.DataHora = DateTime.Now;
                entrada.Quantidade = request.Quantidade;
                entrada.Mercadorias = new Mercadoria
                {
                    Nome = request.Nome,
                    Fabricante = request.Fabricante,
                    Descricao = request.Descricao,
                    NumeroRegistro = request.NumeroRegistro,
                    Tipo = request.Tipo
                };                            

                _context.Entradas.Update(entrada);
                _context.SaveChanges();
                return "Item alterado com sucesso!";
            }

            return "Erro ao tentar atualizar";
        }

       
    }
}
