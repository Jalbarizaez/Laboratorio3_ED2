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

        // GET: api/Pizza
        [HttpGet]
        public ActionResult Get()
        {

            Pizzas.Add(new Pizza { nombre = "Domi", descripcion = "", extraQueso = true, ingredientes = new string[] { "queso", "Harina" },masa = "Dura" ,porciones = 8, tamaño= "Mediana" });
            return Ok(Pizzas);
            //return Ok()
        }

        // GET: api/Pizza/
        [HttpGet("{name}")]
        public ActionResult Get(string name)
        {
            if(Pizzas.Exists(x=> x.nombre ==name))
            {

                return Ok(Pizzas.Find(x=> x.nombre == name));
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
                Pizzas.Add(value);
                return Ok();
            }
            else { return BadRequest(); }
        }

        // PUT: api/Pizza/5
        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] Pizza value)
        {
            if(ModelState.IsValid)
            {
                if (Pizzas.Exists(x => x.nombre == name))
                {
                    Pizzas.RemoveAll(x => x.nombre == name);
                    Pizzas.Add(value);
                    return Ok();
                }
                else
                { return NotFound(); }
            }
            else { return BadRequest(); }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            if (Pizzas.Exists(x => x.nombre == name))
            {
                Pizzas.RemoveAll(x => x.nombre == name);
                return Ok();
            }
            else
            { return NotFound(); }
        }
    }
}
