using AutoMapper;
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
        private readonly ILogger<CompaniaController> _logger;
        private readonly IMapper _mapper;

        public CompaniaController(ApplicationDbContext db, ILogger<CompaniaController> logger,
                                    IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _db = db;
            _response = new ResponseDto();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            _logger.LogInformation("Listado de Companias");
            var lista = await _db.Compania.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Compania";

            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetCompania")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compania>> GetCompania(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Debe de Enviar el ID");
                _response.Mensaje = "Debe de Enviar el ID";
                _response.IsExitoso = false;
                return BadRequest(_response);
            }

            var comp = await _db.Compania.FindAsync(id);

            if (comp == null)
            {
                _logger.LogError("Compañia No Existe!");
                _response.Mensaje = "Compañia No Existe!";
                _response.IsExitoso = false;
                return NotFound(_response);
            }

            _response.Resultado = comp;
            _response.Mensaje = "Datos del Compania " + comp.Id;
            return Ok(_response);  // Status code = 200
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compania>> PostCompania([FromBody] CompaniaDto companiaDto)
        {

            if (companiaDto == null)
            {
                _response.Mensaje = "Informacion Incorrecta";
                _response.IsExitoso = false;
                return BadRequest(_response);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companiaExiste = await _db.Compania.FirstOrDefaultAsync
                                        (c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower());

            if (companiaExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre de la Compañia ya existe!");
                return BadRequest(ModelState);
            }

            Compania compania = _mapper.Map<Compania>(companiaDto);

            await _db.Compania.AddAsync(compania);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCompania", new { id = compania.Id }, compania); // Status Code= 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutCompania(int id, [FromBody] CompaniaDto companiaDto)
        {
            if (id != companiaDto.Id)
            {
                return BadRequest("Id de Compania no Coincide");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companiaExiste = await _db.Compania.FirstOrDefaultAsync(
                                    c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower()
                                    && c.Id != companiaDto.Id);
            if (companiaExiste != null)
            {
                ModelState.AddModelError("NombreDuplicado", "Nombre de la compania ya Existe!");
                return BadRequest(ModelState);
            }

             Compania compania = _mapper.Map<Compania>(companiaDto);

            _db.Update(compania);
            await _db.SaveChangesAsync();
            return Ok(compania);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCompania(int id)
        {
            var compania = await _db.Compania.FindAsync(id);
            if (compania == null)
            {
                return NotFound();
            }
            _db.Compania.Remove(compania);
            await _db.SaveChangesAsync();
            return NoContent();
        }



    }
}