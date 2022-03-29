using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
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
        WorkWithFiles();
    }
    public void WorkWithFiles()
    {
        string dir = Combine(CurrentDirectory, "Datos", "Prestamos");
        CreateDirectory(dir);

        string textFile = Combine(dir, "Prestamos.txt");

        if (File.Exists(textFile))
        {
            File.AppendAllText(textFile, $"num.Cuenta: {nCuenta}, Monto: {monto}, Tiempo: {tiempo} meses, Fecha prestamo: {fecha_prestamo}, intereses: {interes}%\n");
        }
        else
        {
            File.WriteAllText(textFile, $"num.Cuenta: {nCuenta}, Monto: {monto}, Tiempo: {tiempo} meses, Fecha prestamo: {fecha_prestamo}, intereses: {interes}%\n");
        }

    }

}