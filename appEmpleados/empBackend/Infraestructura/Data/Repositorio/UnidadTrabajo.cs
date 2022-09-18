using Infraestructura.Data.IRepositorio;
using Infraestructura.Data.Repositorio.IRepositio;

namespace Infraestructura.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ICompaniaRepositorio Compania {get; private set;}
        public IEmpleadoRepositorio Empleado {get; private set;}

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Compania = new CompaniaRepositorio(db);
            Empleado = new EmpleadoRepositorio(db);
        }
      
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
           await _db.SaveChangesAsync();
        }
    }
}