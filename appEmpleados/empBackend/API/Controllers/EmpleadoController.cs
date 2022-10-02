using System.Net;
using AutoMapper;
using Core.Dto;
using Core.Entidades;
using Core.Especificaciones;
using Infraestructura.Data;
using Infraestructura.Data.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private ResponseDto _response;
        private ResponsePaginadorDto _responsePaginador;
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public EmpleadoController(IUnidadTrabajo unidadTrabajo, ILogger<EmpleadoController> logger,
                                    IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
            _logger = logger;

            _response = new ResponseDto();
            _responsePaginador = new ResponsePaginadorDto();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmpleadoReadDto>>> GetEmpleados(
            [FromQuery] Parametros parametros
        )
        {
            _logger.LogInformation("Listado de Empleados");
            var lista = await _unidadTrabajo.Empleado.ObtenerTodosPaginado(
                                               parametros,
                                               incluirPropiedades: "Compania",
                                               orderBy: e => e.OrderBy(e => e.Apellidos)
                                                             .ThenBy(e => e.Nombres));

            _responsePaginador.TotalPaginas = lista.MetaData.TotalPages;
            _responsePaginador.TotalRegistros = lista.MetaData.TotalCount;
            _responsePaginador.PageSize = lista.MetaData.PageSize;
            _responsePaginador.Resultado = _mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoReadDto>>(lista);
            _responsePaginador.StatusCode = HttpStatusCode.OK;
            _responsePaginador.Mensaje = "Listado de Empleados";

            return Ok(_responsePaginador);
        }

        [HttpGet("{id}", Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Debe de Enviar el ID");
                _response.Mensaje = "Debe de Enviar el ID";
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                return BadRequest(_response);
            }

            var emp = await _unidadTrabajo.Empleado.ObtenerPrimero(e => e.Id == id, incluirPropiedades: "Compania");

            if (emp == null)
            {
                _logger.LogError("Empleado No Existe!");
                _response.Mensaje = "Empleado No Existe!";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Resultado = _mapper.Map<Empleado, EmpleadoReadDto>(emp);
            _response.Mensaje = "Datos del Empleado " + emp.Id;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);  // Status code = 200
        }


        [HttpGet]
        [Route("EmpleadosPorCompania/{companiaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmpleadoReadDto>>> GetEmpleadosPorCompania(int companiaId)
        {
            _logger.LogInformation("Listado de Empleados por Compania");
            var lista = await _unidadTrabajo.Empleado.ObtenerTodos(e => e.CompaniaId == companiaId, incluirPropiedades: "Compania");
            _response.Resultado = _mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoReadDto>>(lista);
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Mensaje = "Listado de Empleados por Compania";
            return Ok(_response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody] EmpleadoUpsertDto empleadoDto)
        {

            if (empleadoDto == null)
            {
                _response.Mensaje = "Informacion Incorrecta";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (!ModelState.IsValid)
            {
                // return BadRequest(ModelState);
                _response.Mensaje = "Informacion Incorrecta";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var empleadoExiste = await _unidadTrabajo.Empleado.ObtenerPrimero(
                                         c => c.Apellidos.ToLower() == empleadoDto.Apellidos.ToLower() &&
                                              c.Nombres.ToLower() == empleadoDto.Nombres.ToLower()
                                        );

            if (empleadoExiste != null)
            {
                // ModelState.AddModelError("NombreDuplicado", "Nombre del Empleado ya existe!");
                // return BadRequest(ModelState);
                _response.Mensaje = "Nombre del Empleado ya existe!";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;

            }

            Empleado empleado = _mapper.Map<Empleado>(empleadoDto);

            await _unidadTrabajo.Empleado.Agregar(empleado);
            await _unidadTrabajo.Guardar();
            _response.Mensaje = "Empleado Guardado con Exito!";
            _response.IsExitoso = true;
            _response.Resultado = empleado;
            _response.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetEmpleado", new { id = empleado.Id }, _response); // Status Code= 201
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutEmpleado(int id, [FromBody] EmpleadoUpsertDto empleadoDto)
        {
            if (id != empleadoDto.Id)
            {
                // return BadRequest("Id del Empleado no Coincide");
                _response.Mensaje = "d del Empleado no Coincide";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                _response.Mensaje = "Informacion Incorrecta";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var empleadoExiste = await _unidadTrabajo.Empleado.ObtenerPrimero(
                                        c => c.Apellidos.ToLower() == empleadoDto.Apellidos.ToLower()
                                        && c.Nombres.ToLower() == empleadoDto.Nombres.ToLower()
                                        && c.Id != empleadoDto.Id
                                        );

            if (empleadoExiste != null)
            {
                // ModelState.AddModelError("NombreDuplicado", "Nombre del empleado ya Existe!");
                // return BadRequest(ModelState);
                _response.Mensaje = "Nombre del empleado ya Existe!";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Empleado empleado = _mapper.Map<Empleado>(empleadoDto);

            _unidadTrabajo.Empleado.Actualizar(empleado);
            await _unidadTrabajo.Guardar();
            _response.Mensaje = "Empleado guardado con Exito";
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _unidadTrabajo.Empleado.ObtenerPrimero(e => e.Id == id);
            if (empleado == null)
            {
                // return NotFound();
                _response.Mensaje = "Empleado No existe";
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            _unidadTrabajo.Empleado.Remover(empleado);
            await _unidadTrabajo.Guardar();
            _response.Mensaje = "Empleado eliminado Exitosamente";
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }



    }
}