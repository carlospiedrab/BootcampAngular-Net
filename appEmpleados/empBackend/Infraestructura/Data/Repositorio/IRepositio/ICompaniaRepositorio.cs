using Core.Entidades;

namespace Infraestructura.Data.Repositorio.IRepositio
{
    public interface ICompaniaRepositorio : IRepositorio<Compania>
    {
        void Actualizar(Compania compania);
    }
}