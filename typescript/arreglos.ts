// Arreglos
let personas: string[] = ['Carlos', 'Roberto', 'Carmen'];
personas.push('NuevoNombre');

// Objetos

interface IEmpleado {
    nombres: string;
    apellidos: string;
    direccion: string;
    telefonos: string[];
    sueldo: number;
    cargo?: string;
}

const empleado: IEmpleado = {
    nombres: 'Carlos Ricardo',
    apellidos: 'Piedra',
    direccion: '8569 San Fernando Los Angeles',
    telefonos: ['81158-5858', '5545455'],
    sueldo: 5000,    
}
console.table(empleado);




