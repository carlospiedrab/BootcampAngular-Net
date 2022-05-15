"use strict";
exports.__esModule = true;
exports.calcularTotal = void 0;
function calcularTotal(productos) {
    var total = 0;
    productos.forEach(function (producto) {
        total += producto.precio;
    });
    return total;
}
exports.calcularTotal = calcularTotal;
