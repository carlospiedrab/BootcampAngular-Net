using Core.Entidades;
using Infraestructura.Data.Repositorio.IRepositio;

namespace Infraestructura.Data.Repositorio
{

    public interface IEmpleadoRepositorio : IRepositorio<Empleado>
    {
        void Actualizar(Empleado empleado);
    }
}