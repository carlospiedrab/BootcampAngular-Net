namespace OrientadoObjetos.Interfaces
{
    public interface IVehiculo
    {
        void CambiarCarrera(int x);
        void Acelerar(int x);
        void AplicarFrenos(int x);
        void imprimirEstados();

    }
}