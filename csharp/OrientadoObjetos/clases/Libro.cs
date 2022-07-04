namespace OrientadoObjetos.clases
{
    public class Libro : Publicacion
    {
       
        //public string Descripcion { get => $"Libro: {this.Titulo} escrito por {this.Autor}";  }

        public Libro(string titulo, string autor, int paginas) :base(titulo,autor,paginas)
        {
            
        }
        
        public override string ObtenerDescripcion(){
            return $"Libro:  {this.Titulo} escrito por {this.Autor} con {this.Paginas} paginas";
        }
        

    }
}