using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml.Serialization;
public class Empleado
{
    [XmlElement("nEmpleado")]
    public uint nEmpleado;
    [XmlElement("Nombres")]
    public string nombre;
    [XmlElement("Apellidos")]
    public string apellido;
    [XmlElement("Fecha_nacimiento")]
    public DateTime nacimiento;

    public Empleado()
    {

    }

    public Empleado(uint nEmpleado, string? nombre, string? apellido, DateTime nacimiento)
    {
        this.nEmpleado = nEmpleado;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nacimiento = nacimiento;
    }
}