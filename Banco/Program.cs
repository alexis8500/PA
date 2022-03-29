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
            var user = new Usuario(1, "Alexis", "Perez", DateOnly.Parse("04/02/2002"));
            user.setNip(1234);
            usuarios.Add(user);

            var empleado = new Empleado(20, "Mario", "Quevedo", DateOnly.Parse("10/11/2000"));
            empleados.Add(empleado);

            var gerente = new Gerente(30);
            gerente.setMasterKey("password");
            gerentes.Add(gerente);

            Interfaz();
        }

    }
}