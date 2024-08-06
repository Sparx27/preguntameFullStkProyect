using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using preguntameWebAPI.DTOs;
using preguntameWebAPI.Services.Interfaces;

namespace preguntameWebAPI.Controllers
{
    [Route("api/paises")]
    [ApiController]
    public class PaiseController : ControllerBase
    {
        private IPaiseService _paiseService;
        public PaiseController(
            IPaiseService paiseService)
        {
            _paiseService = paiseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaiseDTO>>> Get() => await GetAll();

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PaiseDTO>>> GetAll() => Ok(await _paiseService.GetAll());

        [HttpGet("{code}")]
        public async Task<ActionResult<PaiseDTO>> GetByCode(string code) => 
            await _paiseService.GetByCode(code) is PaiseDTO paise ? Ok(paise) : NotFound("No se encontró un país con ese código");
    }
}
