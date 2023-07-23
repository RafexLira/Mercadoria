using Microsoft.AspNetCore.Mvc;
using webapi.Repositories;
using webapi.Request;

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
        [Route("AddEntrada")]
        public string AddEntrada([FromBody] EntradaRequest Request)
        {
            return _mercadoriaRepo.AddEntrada(Request);
        }      

        [HttpGet]
        [Route("GetEntrada")]
        public string GetEntrada()
        {
            var mercadoria = _mercadoriaRepo.GetEntrada();
            return mercadoria;
        }       

        [HttpPost]
        [Route("GetEntrada/id")]
        public string GetEntradaById([FromBody] int id)
        {              
            return _mercadoriaRepo.GetEntradaById(id);           
        }

        [HttpGet]
        [Route("GetSaida")]
        public string GetSaida()
        {
            var mercadoria = _mercadoriaRepo.GetSaida();
            return mercadoria;
        }

        [HttpPost]
        [Route("GetSaida/id")]
        public string GetSaidaById([FromBody] int id)
        {
            return _mercadoriaRepo.GetSaidaById(id);
        }       

        [HttpPut]
        [Route("AddSaida")]
        public string AddSaida([FromBody] SaidaRequest request)
        {
            return _mercadoriaRepo.AddSaida(request);
        }

        [HttpDelete]
        [Route("DeleteMercadoria")]
        public string DeleteMercadoria([FromBody] int id)
        {
            return _mercadoriaRepo.DeleteMercadoria(id);
        }

        [HttpPut]
        [Route("UpdateMercadoria")]
        public string UpdateMercadoria([FromBody] UpdateRequest Request)
        {
            return _mercadoriaRepo.UpdateMercadoria(Request);
        }
    }
}

