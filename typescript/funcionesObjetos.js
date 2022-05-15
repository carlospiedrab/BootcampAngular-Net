var deuda = function (cliente, monto) {
    cliente.credito += monto;
};
var nuevoCliente = {
    nombres: 'Carlos',
    apellidos: 'Piedra',
    credito: 2000,
    mostrarCliente: function () {
        console.log("Credito del cliente: ".concat(this.nombres, " ").concat(this.apellidos, " es ").concat(this.credito));
    }
};
deuda(nuevoCliente, 200);
nuevoCliente.mostrarCliente();
