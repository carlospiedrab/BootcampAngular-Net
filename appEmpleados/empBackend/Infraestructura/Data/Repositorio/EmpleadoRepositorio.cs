using Core.Entidades;

namespace Infraestructura.Data.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Actualizar(Empleado empleado)
        {
            var empleadoDb = _db.Empleado.FirstOrDefault(c => c.Id == empleado.Id);
            if (empleadoDb != null)
            {
                empleadoDb.Apellidos = empleado.Apellidos;
                empleadoDb.Nombres = empleado.Nombres;
                empleadoDb.Cargo = empleado.Cargo;
                empleadoDb.CompaniaId = empleado.CompaniaId;
                _db.SaveChanges();
            }
        }
    }
}