using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;

        public CompaniaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();

        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            var lista = await _db.Compania.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje="Listado de Compania";
                          
            return Ok(_response);
        }
        
        [HttpGet("{id}", Name ="GetCompania")]
        public async Task<ActionResult<Compania>> GetCompania(int id)
        {
            var comp = await _db.Compania.FindAsync(id);
            _response.Resultado = comp;
            _response.Mensaje="Datos del Compania "+ comp.Id;
            return Ok(_response);  // Status code = 200
        }
       
        [HttpPost]
        public async Task<ActionResult<Compania>> PostCompania([FromBody] Compania compania ){
            await _db.Compania.AddAsync(compania);            
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCompania", new {id = compania.Id}, compania); // Status Code= 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompania(int id, [FromBody] Compania compania){
            if(id != compania.Id){
                return BadRequest("Id de Compania no Coincide");
            }
            _db.Update(compania);
            await _db.SaveChangesAsync();
            return Ok(compania);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompania(int id)
        {
            var compania = await _db.Compania.FindAsync(id);
            if(compania == null){
                return NotFound();
            }
            _db.Compania.Remove(compania);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        


    }
}