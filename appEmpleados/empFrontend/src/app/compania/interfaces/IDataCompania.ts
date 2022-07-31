export interface IDataCompania {
  isExitoso: boolean;
  resultado: Compania[];
  mensaje:   string;
}

export interface Compania {
  id:             number;
  nombreCompania: string;
  direccion:      string;
  telefono:       string;
  telefono2:      string;
}
