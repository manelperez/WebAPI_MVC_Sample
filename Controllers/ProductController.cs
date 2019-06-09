using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiMvc.Models;

namespace WebApiMvc.Controllers
{
    [Route("api/webapimvc")]
    [ApiController]
    public class WebApiMvcController : ControllerBase
    {
        Logic _logic = new Logic();

        // GET api/webapimvc
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            List<Product> products = _logic.GetAllProducts().ToList();
            if (products.Count > 0)
            {
                return Ok(products);
            }
            else
            {
                return NotFound("No hay nigún Producto.");
            }
        }

        // GET api/webapimvc/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (id > 0)
            {
                Product product = _logic.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound("No se ha encontrado el Producto.");
                }
            }
            else
            {
                return BadRequest("El ID de producto no es correcto.");
            }
        }

        // POST api/webapimvc
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product value)
        {
            if (ModelState.IsValid) // Es un producto válido
            {
                _logic.AddProduct(value);
                return Ok(value);
            }
            else
            {
                return BadRequest("El producto introducido no es válido.");
            }

        }

        // PUT api/webapimvc/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            if (ModelState.IsValid) // Es un producto válido
            {
                _logic.UpdateProduct(id, value);
            }
        }

        // DELETE api/webapimvc/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid) // Es un producto válido
            {
                _logic.DeleteProduct(id);
            }
        }
    }
}