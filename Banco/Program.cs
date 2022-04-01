using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
namespace Banco
{
    public partial class Program
    {
        static List<Usuario> usuarios = new List<Usuario>();

        static List<Empleado> empleados = new List<Empleado>();

        static List<Gerente> gerentes = new List<Gerente>();

        static List<Prestamo> prestamos = new List<Prestamo>();



        static void Main(string[] args)
        {
            JsonDeserializationEmployers();
            UsuarioJsonDeserialization();
            PrestamoJsonDeserialization();

            if (usuarios.Count == 0)
            {
                var user = new Usuario(1, "Juan", "Perez", DateTime.Parse("01/01/2000"), 1234);
                usuarios.Add(user);
                UsuarioJsonSerialization(usuarios);
            }

            if (empleados.Count == 0)
            {
                var empleado = new Empleado(2, "Pedro", "Perez", DateTime.Parse("01/01/2000"));
                empleados.Add(empleado);
                JsonSerializationEmployers(empleados);
            }

            XmlSerializationEmployers(empleados);
            UsuarioXmlSerialization(usuarios);
            Interfaz();

        }

    }
}