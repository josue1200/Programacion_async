using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_empresa.Models;
namespace web_api_empresa.Controllers{

[Route("api/[controller]")]
    public class PuestosController : Controller {
        private Conexion dbConexion;
        public PuestosController(){
            dbConexion = Conectar.Create();

        }
        
        [HttpGet]
        public ActionResult Get() {
            return Ok(dbConexion.Puestos.ToArray());

        }
        
        [HttpGet("{id}")]
         public ActionResult Get(int id) {
             var puestos = dbConexion.Puestos.SingleOrDefault(a => a.id_puesto == id);
            if (puestos != null) {
                return Ok(puestos);
            } else {
                return NotFound();
            }
        }


[HttpPost]
        public ActionResult Post([FromBody] Puestos puestos){
            if (!ModelState.IsValid)
            return BadRequest();
             dbConexion.Puestos.Add(puestos);
             dbConexion.SaveChanges();
             return Created("api/puestos",puestos);
        }

    [HttpPut("{id}")]
    public ActionResult Put(int id,[FromBody] Puestos puestos){
        var v_puestos = dbConexion.Puestos.SingleOrDefault(a => a.id_puesto == id);
        if (v_puestos != null && ModelState.IsValid) {
            dbConexion.Entry(v_puestos).CurrentValues.SetValues(puestos);
            dbConexion.SaveChanges();
           
                return Ok();
            } else {
                return BadRequest();
            }
    }

[HttpDelete("{id}")]
public ActionResult Delete(int id) {
    var puestos = dbConexion.Puestos.SingleOrDefault(a => a.id_puesto == id);
    if(puestos!= null) {
        dbConexion.Puestos.Remove(puestos);
        dbConexion.SaveChanges();
                return Ok();
        } 
        else {    return NotFound();
        }


}

}

}