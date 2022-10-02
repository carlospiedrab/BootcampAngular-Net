namespace Core.Especificaciones
{
    public class MetaData
    {
        public int CurrentPage { get; set; }  // Pagina Actual
        public int TotalPages { get; set; }  // Total de Paginas

        public int PageSize { get; set; }   // Tamano de la pagina
        public int TotalCount { get; set; }  // Total de registro

        public bool HasPrevious => CurrentPage > 1;   // Paginas Previas 
        public bool HasNext => CurrentPage < TotalPages;  // Pagina siguientes 


    }
}