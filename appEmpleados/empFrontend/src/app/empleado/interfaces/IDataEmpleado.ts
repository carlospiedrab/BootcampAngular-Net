export interface IDataEmpleado {
  totalRegistros: number;
  totalPaginas:   number;
  pageSize:       number;
  statusCode:     number;
  isExitoso:      boolean;
  resultado:      Empleado[];
  mensaje:        string;
}

export interface Empleado {
  apellidos: string;
  nombres:   string;
  cargo:     string;
  compania:  string;
}
