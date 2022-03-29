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
                string? nip = ReadLine();
                WriteLine();
                DateOnly nacimiento = DateOnly.Parse(fecha);
                Usuario user = new Usuario(nCuenta, nombre, apellido, nacimiento);
                user.setNip(uint.Parse(nip));
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