
using System.Collections;
using OrientadoObjetos.clases;

Libro libro1 = new Libro("Fundamentos de C#", "Clark Nathan", 300);
Libro libro2 = new Libro("Programacion en C#", "Luc Gervais", 400);

Console.WriteLine(libro1.ObtenerDescripcion());
Console.WriteLine(libro2.ObtenerDescripcion());

Revista revista = new Revista("PC World", "IDG", 100, 30);

Console.WriteLine(revista.ObtenerDescripcion());

// TODO Interfaces  
Bicicleta bicicleta = new Bicicleta();
bicicleta.CambiarCarrera(1);
bicicleta.Acelerar(3);
bicicleta.imprimirEstados();

// Todo Generics

ArrayList arr = new ArrayList();
arr.Add(1);
arr.Add(2);
arr.Add("2255");

List<int> arrGen = new List<int>();
arrGen.Add(1);




















