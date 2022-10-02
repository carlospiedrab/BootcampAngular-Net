using System.Net;

namespace Core.Dto
{
    public class ResponsePaginadorDto
    {
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int PageSize { get; set; }
         public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } =true;

        public object Resultado { get; set; }

        public string Mensaje { get; set; }
    }
}