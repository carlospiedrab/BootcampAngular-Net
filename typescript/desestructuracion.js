var pelicula = {
    id: 1,
    titulo: 'Star Wars - guerra de los Clones',
    descripcion: 'Saga de Star Wars',
    anio: 2001,
    director: {
        nombres: 'George',
        apellidos: 'Lucas'
    }
};
var titulo = pelicula.titulo, anio = pelicula.anio, director = pelicula.director;
var nombres = director.nombres;
console.log('Pelicula: ', titulo);
console.log('Anio: ', anio);
