namespace Core.Especificaciones
{
    public class PagedList<T>  :List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)  // 1.5  lo transforma a 2 
            };
            AddRange(items);  // Agrega los elementos de la coleccion al final de la lista
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> entidad, int pageNumber, int pageSize)
        {
            var count = entidad.Count();   //  100  
            var items = entidad.Skip((pageNumber -1) * pageSize)
                               .Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

    }
}