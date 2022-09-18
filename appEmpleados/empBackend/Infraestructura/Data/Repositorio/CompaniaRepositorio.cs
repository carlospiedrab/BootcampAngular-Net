using Core.Entidades;
using Infraestructura.Data.Repositorio.IRepositio;

namespace Infraestructura.Data.Repositorio
{
    public class CompaniaRepositorio : Repositorio<Compania>, ICompaniaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CompaniaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Actualizar(Compania compania)
        {
            var companiaDB = _db.Compania.FirstOrDefault(c => c.Id == compania.Id);
            if (companiaDB != null)
            {
                companiaDB.NombreCompania = compania.NombreCompania;
                companiaDB.Direccion = compania.Direccion;
                companiaDB.Telefono = compania.Telefono;
                companiaDB.Telefono2 = compania.Telefono2;
                _db.SaveChanges();
            }
        }
    }
}