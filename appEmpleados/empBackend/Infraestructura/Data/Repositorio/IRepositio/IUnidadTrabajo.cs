using Infraestructura.Data.Repositorio;
using Infraestructura.Data.Repositorio.IRepositio;

namespace Infraestructura.Data.IRepositorio
{
    public interface IUnidadTrabajo :IDisposable
    {

        ICompaniaRepositorio Compania {get; }
        IEmpleadoRepositorio Empleado {get; }

        Task Guardar();
    }
}