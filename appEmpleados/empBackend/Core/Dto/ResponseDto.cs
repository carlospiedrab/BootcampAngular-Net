using System.Net;

namespace Core.Dto
{
    public class ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } =true;

        public object Resultado { get; set; }

        public string Mensaje { get; set; }
    }
}