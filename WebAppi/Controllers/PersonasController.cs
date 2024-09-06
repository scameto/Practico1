using BL.BLs;
using BL.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase {

        private readonly IBL_Personas _blPersonas;

        public PersonasController(IBL_Personas blPersonas) {
            _blPersonas = blPersonas;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<Persona> Get() {
            return _blPersonas.GetPersonas();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] Persona value) {
            _blPersonas.AddPersona(value);
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
