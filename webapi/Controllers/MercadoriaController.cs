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
        [Route("Post")]
        public string PostMercadoria([FromBody] Request Request)
        {
            return _mercadoriaRepo.AddMercadoria(Request);
        }

        [HttpGet]
        [Route("getall")]
        public string GetMercadoria()
        {
            var mercadoria = _mercadoriaRepo.GetMercadoria();
            return mercadoria;
        }
        [HttpPost]
        [Route("getbyid")]
        public string GetByIdMercadoria([FromBody] int id)
        {              
            return _mercadoriaRepo.GetByIdMercadoria(id);           
        }

        [HttpDelete]
        [Route("delete")]
        public string DeleteMercadoria([FromBody] int id)
        {
            return _mercadoriaRepo.DeleteMercadoria(id);
        }

        [HttpPut]
        [Route("Update")]
        public string UpdateMercadoria([FromBody] Request Request)
        {
            return _mercadoriaRepo.UpdateMercadoria(Request);
        }
    }
}

