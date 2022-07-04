namespace OrientadoObjetos.clases
{
    public class Publicacion
    {
        
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }

        public Publicacion(string titulo, string autor, int paginas)
        {
            this.Titulo= titulo;
            this.Autor =autor;
            this.Paginas =paginas;
        }

        public virtual string ObtenerDescripcion() {
            return $"{this.Titulo} autor {this.Autor}";
        }


    }
}