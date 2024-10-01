using _2._7_back.Data.Models;
using _2._7_back.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2._7_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiceServicio _servicio;

        public ServiciosController(IServiceServicio servicio)
        {
            _servicio = servicio;
        }






        // GET: api/<ServiciosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

            return Ok(await _servicio.GetAll());

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var devuelto = await _servicio.GetById(id);
                if (devuelto != null)
                {
                    return Ok(devuelto);
                }
                return NotFound("Buscate otro que ese no existe");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                _servicio.Add(servicio);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TServicio servicio)
        {
            try
            {
                await _servicio.Update(servicio);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
           
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servicio.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
