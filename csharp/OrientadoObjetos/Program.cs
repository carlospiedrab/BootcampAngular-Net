
using OrientadoObjetos.clases;

Libro libro1 = new Libro("Fundamentos de C#", "Clark Nathan", 300);
Libro libro2 = new Libro("Programacion en C#", "Luc Gervais", 400);

Console.WriteLine(libro1.ObtenerDescripcion());
Console.WriteLine(libro2.ObtenerDescripcion());

Revista revista = new Revista("PC World", "IDG", 100, 30);

Console.WriteLine(revista.ObtenerDescripcion());
