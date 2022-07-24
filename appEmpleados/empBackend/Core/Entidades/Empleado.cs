using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Empleado
    {   
        [Key]
        public int Id { get; set; }

        public string Apellidos { get; set; }

        public string Nombres { get; set; }

        public string Cargo { get; set; }

        public int CompaniaId { get; set; }

        [ForeignKey("CompaniaId")]
        public Compania Compania { get; set; }

       
    }
}