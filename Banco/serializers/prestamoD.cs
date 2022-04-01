using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace Banco
{
  public partial class Program
  {
    static List<Prestamo> prestamosD = new List<Prestamo>();

    private static void PrestamoJsonSerialization(List<Prestamo> prestamosD)
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "History.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, prestamosD);
      }
    }

    private static void PrestamoJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      string jsonPath = Combine(dir, "History.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          prestamos = (List<Prestamo>)jss.Deserialize(jsonStream, typeof(List<Prestamo>));
        }
      }
      else
      {
        prestamos = new List<Prestamo>();
      }
    }

    private static void PrestamoXmlSerialization(List<Prestamo> prestamos)
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "History.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xss = new XmlSerializer(typeof(List<Prestamo>));
        xss.Serialize(xmlStream, prestamos);
      }
    }
  }
}