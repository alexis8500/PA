using System;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;

namespace Banco
{
  public partial class Program
  {
    static List<Usuario> usuarioD = new List<Usuario>();

    private static void UsuarioJsonSerialization(List<Usuario> usuarioD)
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      CreateDirectory(dir);

      string jsonPath = Combine(dir, "Users.json");
      using (StreamWriter jsonStream = File.CreateText(jsonPath))
      {
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, usuarioD);
      }
    }

    private static void UsuarioJsonDeserialization()
    {
      string dir = Combine(CurrentDirectory, "Data", "JsonData");
      string jsonPath = Combine(dir, "Users.json");

      if (File.Exists(jsonPath))
      {
        using (StreamReader jsonStream = File.OpenText(jsonPath))
        {
          Newtonsoft.Json.JsonSerializer jss = new();
          usuarioD = (List<Usuario>)jss.Deserialize(jsonStream, typeof(List<Usuario>));
        }
      }
      else
      {
        usuarioD = new List<Usuario>();
      }

    }

    private static void UsuarioXmlSerialization(List<Usuario> usuarioD)
    {
      string dir = Combine(CurrentDirectory, "Data", "XmlData");
      CreateDirectory(dir);

      string xmlPath = Combine(dir, "Users.xml");
      using (StreamWriter xmlStream = File.CreateText(xmlPath))
      {
        XmlSerializer xss = new XmlSerializer(typeof(List<Usuario>));
        xss.Serialize(xmlStream, usuarioD);
      }
    }
  }
}