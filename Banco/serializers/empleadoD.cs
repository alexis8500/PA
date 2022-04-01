using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace Banco
{
  public partial class Program
  {
    static List<Empleado> empleadoD = new List<Empleado>();

    private static void JsonSerializationEmployers(List<Empleado> empleadoD)
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "Employers.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, empleadoD);
      }
    }

    private static void JsonDeserializationEmployers()
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      string jsonPath = Combine(dir, "Employers.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          empleadoD = (List<Empleado>)jss.Deserialize(jsonStream, typeof(List<Empleado>));
        }
      }
      else
      {
        empleadoD = new List<Empleado>();
      }

    }

    private static void XmlSerializationEmployers(List<Empleado> empleadoD)
    {
      string dir = Combine(CurrentDirectory, "Data", "XmlData");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "Employers.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xss = new XmlSerializer(typeof(List<Empleado>));
        xss.Serialize(xmlStream, empleadoD);
      }
    }
  }
}