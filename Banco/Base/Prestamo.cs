public class Prestamo
{
    public uint interes;
    public float monto;
    public uint tiempo;
    public uint nCuenta;
    public DateTime fecha_prestamo;

    public Prestamo(uint interes, float monto, uint tiempo, uint nCuenta)
    {
        this.interes = interes;
        this.monto = monto;
        this.tiempo = tiempo;
        this.nCuenta = nCuenta;
        this.fecha_prestamo = DateTime.Now;
    }

}