using System.Net;
using AutoMapper;
using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Infraestructura.Data.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : ControllerBase
    {

        private ResponseDto _response;
        private readonly ILogger<CompaniaController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CompaniaController(IUnidadTrabajo unidadTrabajo, ILogger<CompaniaController> logger,
                                    IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
            _logger = logger;
            _response = new ResponseDto();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            _logger.LogInformation("Listado de Companias");
            var lista = await _unidadTrabajo.Compania.ObtenerTodos();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Compania";
            _response.StatusCode = HttpStatusCode.OK;

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
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var comp = await _unidadTrabajo.Compania.ObtenerPrimero(c => c.Id == id);

            if (comp == null)
            {
                _logger.LogError("Compañia No Existe!");
                _response.Mensaje = "Compañia No Existe!";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Resultado = comp;
            _response.Mensaje = "Datos del Compania " + comp.Id;
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
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
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companiaExiste = await _unidadTrabajo.Compania.ObtenerPrimero(
                c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower()
                );

            if (companiaExiste != null)
            {
                //ModelState.AddModelError("NombreDuplicado", "Nombre de la Compañia ya existe!");
                _response.IsExitoso = false;
                _response.Mensaje = "Nombre de la Compañia ya existe!";
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Compania compania = _mapper.Map<Compania>(companiaDto);

            await _unidadTrabajo.Compania.Agregar(compania);
            await _unidadTrabajo.Guardar();
            _response.IsExitoso = true;
            _response.Mensaje = "Compania Guardada con Exito";
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtRoute("GetCompania", new { id = compania.Id }, _response); // Status Code= 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutCompania(int id, [FromBody] CompaniaDto companiaDto)
        {
            if (id != companiaDto.Id)
            {
                _response.IsExitoso = false;
                _response.Mensaje = "Id de Compania no Coincide";
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companiaExiste = await _unidadTrabajo.Compania.ObtenerPrimero(
                                    c => c.NombreCompania.ToLower() == companiaDto.NombreCompania.ToLower()
                                    && c.Id != companiaDto.Id);

            if (companiaExiste != null)
            {
                // ModelState.AddModelError("NombreDuplicado", "Nombre de la compania ya Existe!");
                _response.IsExitoso = false;
                _response.Mensaje = "Nombre de la compania ya Existe!";
                return BadRequest(_response);
            }

            Compania compania = _mapper.Map<Compania>(companiaDto);

            _unidadTrabajo.Compania.Actualizar(compania);
            await _unidadTrabajo.Guardar();
            _response.IsExitoso = true;
            _response.Mensaje = "Compania Actualizada";
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCompania(int id)
        {
            var compania = await _unidadTrabajo.Compania.ObtenerPrimero(c => c.Id == id);
            if (compania == null)
            {
                _response.IsExitoso = false;
                _response.Mensaje = "Compania No existe";
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            _unidadTrabajo.Compania.Remover(compania);
            await _unidadTrabajo.Guardar();
            _response.IsExitoso = true;
            _response.Mensaje = "Compania Eliminada";
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }



    }
}