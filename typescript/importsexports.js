"use strict";
exports.__esModule = true;
var producto_1 = require("./producto");
var listaProductos = [
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
var totalLista = (0, producto_1.calcularTotal)(listaProductos);
console.log(totalLista);
