import { Injectable } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';


@Injectable()
export class MatPaginatorIntlEs extends MatPaginatorIntl {
    override itemsPerPageLabel = 'Registros por Pagina';
}
