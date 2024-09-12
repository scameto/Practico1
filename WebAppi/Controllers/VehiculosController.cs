using BL.IBLs;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase {

        private readonly IBL_Vehiculos _vehiculos;
        public VehiculosController(IBL_Vehiculos vehiculos) {
            _vehiculos = vehiculos;
        }

        // GET: api/<VehiculosController>
        [HttpGet]
        public IEnumerable<Vehiculos> Get() {
            return _vehiculos.GetVehiculos();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{id}")]
        public Vehiculos Get(int id) {
            return _vehiculos.GetVehiculo(id);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public void Post([FromBody] Vehiculos value) {
            _vehiculos.AddVehiculo(value);

        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Vehiculos value) {
            _vehiculos.UpdateVehiculo(value);
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            _vehiculos.RemoveVehiculo(id);
        }

      


    }
}
