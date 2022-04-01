using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml.Serialization;
public class Prestamo
{
    [XmlElement("interes")]
    public uint interes;
    [XmlElement("monto")]
    public float monto;
    [XmlElement("tiempo")]
    public uint tiempo;
    [XmlElement("num_cuenta")]
    public uint nCuenta;
    [XmlElement("fecha_prestamo")]
    public DateTime fecha_prestamo;

    public Prestamo()
    {

    }

    public Prestamo(uint interes, float monto, uint tiempo, uint nCuenta)
    {
        this.interes = interes;
        this.monto = monto;
        this.tiempo = tiempo;
        this.nCuenta = nCuenta;
        this.fecha_prestamo = DateTime.Now;
        // saveToFile();
    }


    // public void WorkWithFiles()
    // {
    //     string dir = Combine(CurrentDirectory, "Datos", "Prestamos");
    //     CreateDirectory(dir);

    //     string textFile = Combine(dir, "Prestamos.txt");

    //     if (File.Exists(textFile))
    //     {
    //         File.AppendAllText(textFile, $"num.Cuenta: {nCuenta}, Monto: {monto}, Tiempo: {tiempo} meses, Fecha prestamo: {fecha_prestamo}, intereses: {interes}%\n");
    //     }
    //     else
    //     {
    //         File.WriteAllText(textFile, $"num.Cuenta: {nCuenta}, Monto: {monto}, Tiempo: {tiempo} meses, Fecha prestamo: {fecha_prestamo}, intereses: {interes}%\n");
    //     }

    // }

}