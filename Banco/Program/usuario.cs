using System;
using static System.Console;
namespace Banco
{

    public partial class Program
    {
        static void CrearUsuario()
        {
            try
            {
                Write("\nIngresa el numero de cuenta : ");
                string? ncuenta = ReadLine();
                uint nCuenta = uint.Parse(ncuenta);
                Write("Ingresa el nombre : ");
                string? nombre = ReadLine();
                Write("Ingresa el apellido : ");
                string? apellido = ReadLine();
                Write("Ingresa el fecha de nacimiento : ");
                string? fecha = ReadLine();
                Write("Ingresa el nip : ");
                string? Nip = ReadLine();
                uint nip = uint.Parse(Nip);
                WriteLine();
                DateTime nacimiento = DateTime.Parse(fecha);
                Usuario user = new Usuario(nCuenta, nombre, apellido, nacimiento, nip);
                usuarios.Add(user);

                WriteLine("El usuario se ha creado satisfactoriamente");
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return;
            }
        }
    }
}