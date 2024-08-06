using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.DTOs.UsuarioPregunta;
using preguntameWebAPI.Services.Interfaces;

namespace preguntameWebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioServie;
        public UsuarioController(IUsuarioService usuarioServie)
        {
            _usuarioServie = usuarioServie;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UsuarioDTO>> Get(string username)
        {
            //Falta de alguna forma corroborar que el usuario en sesion es el mismo al que intenta ingresar por parametros.
            //Solo deberia poder obtener sus datos si el usuarioLogueado == username
            return Ok(await _usuarioServie.GetUsuario(username));
        }

        [HttpGet("{username}/preguntas")]
        public async Task<ActionResult<IEnumerable<UsPrDTO>>> GetPreguntas(string username)
        {
            //Falta de alguna forma corroborar que el usuario en sesion es el mismo al que intenta ingresar por parametros.
            //Solo deberia poder obtener las preguntas si el usuarioLogueado == username
            var liPreguntas = await _usuarioServie.GetPreguntas(username);
            return Ok(liPreguntas);
        }

        [HttpPut("{username}/preguntas")]
        public async Task<IActionResult> ResponderPregunta(string username, UsPrUpdateDTO usPrUpdateDTO)
        {
            try
            {
                await _usuarioServie.ResponderPregunta(usPrUpdateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{username}/respuestas")]
        public async Task<ActionResult<IEnumerable<UsPrDTO>>> GetRespuestas(string username)
        {
            //Nuevamente, falta corroborar que username == usuarioLogueado
            return Ok(await _usuarioServie.GetRespuestas(username));
        }
    }
}
