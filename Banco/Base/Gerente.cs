using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml.Serialization;
public class Gerente
{

    [XmlElement("nEmpleado")]
    public uint nEmpleado;
    [XmlElement("nombres")]
    public string masterKey;

    public Gerente()
    {

    }

    public Gerente(uint nEmpleado, string masterKey)
    {
        this.nEmpleado = nEmpleado;
        this.masterKey = masterKey;

        // saveToFile();
    }

    public interface IGerente
    { }

    //     public void WorkWithFiles()
    // {
    //     string dir = Combine(CurrentDirectory, "Datos", "Gerentes");
    //     CreateDirectory(dir);

    //     string textFile = Combine(dir, "Gerentes.txt");

    //     if (File.Exists(textFile))
    //     {
    //         File.AppendAllText(textFile, $"num.Empleado: {nEmpleado}, masterKey: {masterKey}\n");
    //     }
    //     else
    //     {
    //         File.WriteAllText(textFile, $"num.Empleado: {nEmpleado}, masterKey: {masterKey}\n");
    //     }

    // }
}