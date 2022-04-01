using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml.Serialization;
public class Usuario
{

  [XmlElement("nCuenta")]
  public uint nCuenta;
  [XmlElement("nombres")]
  public string nombre;
  [XmlElement("apellidos")]
  public string apellido;
  [XmlElement("fecha_nacimiento")]
  public DateTime nacimiento;
  [XmlElement("nip")]
  public uint nip;

  public Usuario()
  {

  }
  public Usuario(uint nCuenta, string? nombre, string? apellido, DateTime nacimiento, uint nip)
  {
        this.nCuenta = nCuenta;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nacimiento = nacimiento;
        this.nip = nip;

    // saveToFile();
  }



}