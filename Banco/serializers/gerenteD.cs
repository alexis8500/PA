using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace Banco
{
  public partial class Program
  {
    static List<Gerente> gerentesD = new List<Gerente>();

    private static void GerenteJsonSerialization(List<Gerente> gerentesD)
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "Gerency.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, gerentesD);
      }
    }

    private static void GerenteJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      string jsonPath = Combine(dir, "Gerency.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          gerentes = (List<Gerente>)jss.Deserialize(jsonStream, typeof(List<Gerente>));
        }
      }
      else
      {
        gerentes = new List<Gerente>();
      }
    }

    private static void GerenteXmlSerialization(List<Gerente> gerentes)
    {
      string dir = Combine(CurrentDirectory, "Data", "XmlData");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "Gerency.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xs = new XmlSerializer(typeof(List<Gerente>));
        xs.Serialize(xmlStream, gerentes);
      }
    }
  }
}