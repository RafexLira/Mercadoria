using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class MercadoriaController : Controller
    {
        private readonly MercadoriaRepo _mercadoriaRepo;
        public MercadoriaController(MercadoriaRepo mercadoriaRepo)
        {
            _mercadoriaRepo = mercadoriaRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Entrada> GetMercadoria()
        {
            return _mercadoriaRepo.GetMercadoria();
        }
        [HttpGet]
        [Route("GetbyId")]
        public Entrada GetByIdMercadoria([FromBody] Entrada Request)
        {

            return _mercadoriaRepo.GetByIdMercadoria(Request);
        }

        [HttpGet]
        [Route("Post")]
        public string PostMercadoria([FromBody] Entrada Request)
        {
            return _mercadoriaRepo.AddMercadoria(Request);
        }

        [HttpGet]
        [Route("Delete")]
        public bool DeleteMercadoria([FromBody] Entrada Request)
        {
            return _mercadoriaRepo.DeleteMercadoria(Request);
        }

        [HttpGet]
        [Route("Update")]
        public string UpdateMercadoria([FromBody] Entrada Request)
        {
            return _mercadoriaRepo.UpdateMercadoria(Request);
        }
    }
}

