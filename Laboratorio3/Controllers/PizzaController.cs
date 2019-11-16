using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Laboratorio3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public static List<Pizza> Pizzas = new List<Pizza>();
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: api/Pizza
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_pizzaService.Get());
            
        }

        // GET: api/Pizza/name
        [HttpGet("{name}")]
        public ActionResult Get(string name)
        {
            var pizza = _pizzaService.Get(name);
            if (pizza != null)
            {

                return Ok(pizza);
            }
            else
            { return NotFound(); }
        }

        // POST: api/Pizza
        [HttpPost]
        public ActionResult Post([FromBody] Pizza value)
        {
            if(ModelState.IsValid)
            {
                _pizzaService.Create(value);

                return Ok();
            }
            else { return BadRequest(); }
        }

        // PUT: api/Pizza/name
        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] Pizza value)
        {
            var pizza = _pizzaService.Get(name);

            if (ModelState.IsValid)
            {
                if (pizza != null)
                {
                    _pizzaService.Update(name, value);
                    return Ok();
                }
                else
                { return NotFound(); }
            }
            else { return BadRequest(); }
        }

        // DELETE: api/Delete/name
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var pizza = _pizzaService.Get(name);
            if (pizza != null)
            {
                _pizzaService.Remove(pizza.nombre);
                return Ok();
            }
            else
            { return NotFound(); }
        }
    }
}
