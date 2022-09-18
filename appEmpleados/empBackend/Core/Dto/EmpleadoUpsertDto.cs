namespace Core.Dto
{
    public class EmpleadoUpsertDto
    {
        public int Id { get; set; }

        public string Apellidos { get; set; }

        public string Nombres { get; set; }

        public string Cargo { get; set; }

        public int CompaniaId { get; set; }

    }
}