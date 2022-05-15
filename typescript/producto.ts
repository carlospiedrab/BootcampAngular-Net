
export interface IProducto {
    id: number;
    descripcion: string;
    precio: number;
}

export function calcularTotal(productos: IProducto[]): number {
    let total = 0;
    productos.forEach( (producto) => {
        total += producto.precio;
    } )
    return total;
}