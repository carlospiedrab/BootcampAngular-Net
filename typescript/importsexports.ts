import {  calcularTotal, IProducto } from "./producto";

const listaProductos :IProducto[] = [
    {
        id: 1,
        descripcion: 'Tablet',
        precio: 2000
    },
    {
        id: 2,
        descripcion: 'Laptop',
        precio: 3000
    },
    {
        id: 3,
        descripcion: 'impresora Hp',
        precio: 1500
    }
];

const totalLista = calcularTotal(listaProductos);

console.log(totalLista);


