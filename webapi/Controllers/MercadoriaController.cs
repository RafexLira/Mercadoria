using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Serialization;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaRepo _mercadoriaRepo;
        public MercadoriaController(IMercadoriaRepo mercadoriaRepo)
        {
            _mercadoriaRepo = mercadoriaRepo;
        }

        [HttpPost]
        [Route("AddMercadoria")]
        public string PostMercadoria([FromBody] RequestEntrada Request)
        {
            return _mercadoriaRepo.AddMercadoria(Request);
        }      

        [HttpGet]
        [Route("GetMercadoria")]
        public string GetEntradaMercadoria()
        {
            var mercadoria = _mercadoriaRepo.GetEntradaMercadoria();
            return mercadoria;
        }       

        [HttpPost]
        [Route("GetMercadoria/Id")]
        public string GetByIdEntrada([FromBody] int id)
        {              
            return _mercadoriaRepo.GetByIdEntrada(id);           
        }

        [HttpGet]
        [Route("GetSaidas")]
        public string GetSaida()
        {
            var mercadoria = _mercadoriaRepo.GetSaidaMercadoria();
            return mercadoria;
        }

        [HttpPost]
        [Route("GetSaida/Id")]
        public string GetByIdSaida([FromBody] int id)
        {
            return _mercadoriaRepo.GetByIdSaida(id);
        }

        [HttpPut]
        [Route("AddSaidaMercadoria")]
        public string AddSaidaMercadoria([FromBody] RequestSaida request)
        {
            return _mercadoriaRepo.AddSaidaMercadoria(request);
        }

        [HttpDelete]
        [Route("DeleteMercadoria")]
        public string DeleteMercadoria([FromBody] int id)
        {
            return _mercadoriaRepo.DeleteMercadoria(id);
        }

        [HttpPut]
        [Route("UpdateMercadoria")]
        public string UpdateMercadoria([FromBody] RequestMercadoria Request)
        {
            return _mercadoriaRepo.UpdateMercadoria(Request);
        }
    }
}

