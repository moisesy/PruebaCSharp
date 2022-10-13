using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaHumanBrands.BLL;
using PruebaHumanBrands.MOD;
using PruebaHumanBrands.MOD.Entidades;

namespace PruebaHumanBrands.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Peticion MOSTRAR
        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                PersonaRoutingBLL persona = new(context);
                var personas = await persona.Get();
                return Ok(personas);

            } catch(Exception e)
            {
                return BadRequest(new ResponseData { ResultCode = 400, ResultMessage = $"Bad Request: {e.Message}" });
            }
        }

        // Peticion GUARDAR
        [HttpPost("post")]
        public async Task<ActionResult> Post(Persona persona)
        {
            try
            {
                PersonaRoutingBLL person = new(context);
                await person.Post(persona);
                return Ok();

            } catch (Exception e)
            {
                return BadRequest(new ResponseData { ResultCode = 400, ResultMessage = $"Bad Request: {e.Message}" });
            }
        }


        // Peticion ACTUALIZAR
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> Put(Persona persona, int id)
        {
            try
            {
                PersonaRoutingBLL person = new(context);
                await person.Put(persona, id);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(new ResponseData { ResultCode = 400, ResultMessage = $"Bad Request: {e.Message}" });
            }
        }

        // Peticion DESACTIVAR-ACTIVAR 
        [HttpPut("state/{id:int}")]
        public async Task<ActionResult> State(int id)
        {
            try
            {
                PersonaRoutingBLL person = new(context);
                await person.State(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseData { ResultCode = 400, ResultMessage = $"Bad Request: {e.Message}" });
            }
        }
    }
}
