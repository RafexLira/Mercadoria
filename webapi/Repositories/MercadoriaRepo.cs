using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using webapi.Context;
using webapi.Models;
namespace webapi.Repositories
{
    public class MercadoriaRepo : IMercadoriaRepo
    {
        private MercadoriaContext _context;
        public MercadoriaRepo(MercadoriaContext context)
        {
            _context = context;
        }

        public string GetEntradaMercadoria()
        {
            var result = (from entrada in _context.Entradas
                          join mercadoria in _context.Mercadorias on entrada.Id equals mercadoria.EntradaId
                          //join saida in _context.Saidas on mercadoria.SaidaId equals saida.Id

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
        public string GetByIdEntrada(int id)
        {

            var result = (from entrada in _context.Entradas.Where(x => x.Id == id)
                          join mercadoria in _context.Mercadorias on entrada.Id equals mercadoria.EntradaId
                          //join saida in _context.Saidas on mercadoria.SaidaId equals saida.Id
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

            //var settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};

            return JsonConvert.SerializeObject(result);



            return "Item não encontrado!";
        }
        public string GetSaidaMercadoria()
        {
            var result = (from saida in _context.Saidas
                          join mercadoria in _context.Mercadorias on saida.Id equals mercadoria.EntradaId
                          //join saida in _context.Saidas on mercadoria.SaidaId equals saida.Id

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


            //var settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    NullValueHandling = NullValueHandling.Ignore
            //};

            return JsonConvert.SerializeObject(result);

        }
        public string GetByIdSaida(int id)
        {
            var result = (from saida in _context.Saidas.Where(x => x.Id == id)
                          join mercadoria in _context.Mercadorias on saida.Id equals mercadoria.EntradaId
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


            return "Item não encontrado!";
        }
        public string AddMercadoria(RequestEntrada request)
        {
            if (request.Id == null) return "Preencha os campos adequadamente!";
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
                return "Ocorreu um erro ao tentar encontrar o produto";
            }
            return "Item removido com sucesso!";
        }
        public string UpdateMercadoria(RequestMercadoria request)
        {
            if (request.Id == null) return "Preencha os campos adequadamente!";

            var mercadoria = _context.Mercadorias.FirstOrDefault(x => x.EntradaId == request.Id);

            try
            {
                mercadoria.Nome = request.Nome;
                mercadoria.Fabricante = request.Fabricante;
                mercadoria.Descricao = request.Descricao;
                mercadoria.NumeroRegistro = request.NumeroRegistro;
                mercadoria.Tipo = request.Tipo;

                _context.Mercadorias.Update(mercadoria);
                _context.SaveChanges();

                return "Mercadoria Atualizada!";
            }
            catch
            {
                return "Erro ao tentar atualizar";
            }
        }
        public string AddSaidaMercadoria(RequestSaida request)
        {

            if (request.Id == null) return "Preencha os campos adequadamente!";

            try
            {
                var mercadoria = _context.Mercadorias.Find(request.Id);
                var entrada = _context.Entradas.Find(mercadoria.EntradaId);

                Saida Saida;

                if (mercadoria.GuidSaida != null)
                {
                    Saida = new Saida
                    {
                        Local = request.Local,
                        DataHora = request.DataSaida,
                        Quantidade = request.Quantidade
                    };


                    Saida.GuidSaida = Guid.NewGuid();
                    entrada.Quantidade = entrada.Quantidade - Saida.Quantidade;

                    _context.Saidas.Add(Saida);

                    mercadoria.GuidSaida = Saida.GuidSaida;
                    _context.SaveChanges();

                    return "Saida atualizada com sucesso!";

                }

                Saida = new Saida
                {
                    Local = request.Local,
                    DataHora = request.DataSaida,
                    Quantidade = request.Quantidade
                };

                Saida.GuidSaida = Guid.NewGuid();
                entrada.Quantidade = entrada.Quantidade - Saida.Quantidade;

                _context.Saidas.Add(Saida);

                mercadoria.GuidSaida = Saida.GuidSaida;
                _context.SaveChanges();

                return "Saida adicionada com sucesso!";

            }
            catch
            {
                return "Erro ao tentar adicionar saida";
            }
        }
    }
}

