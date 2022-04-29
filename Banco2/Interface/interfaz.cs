using System;
using static System.Console;

namespace Banco2
{
    partial class Program
    {
        public static void interfaz()
        {
            using (var db = new Models.bancoContext())
            {
                var prestamos = db.Prestamos;
                foreach (var p in prestamos)
                {
                    p.Activo = false;
                }
                db.SaveChanges();
            }

            bool exit = false;
            do
            {
                try
                {
                    WriteLine("\n\tBanco de Préstamos");
                    WriteLine("1. Iniciar sesión");
                    WriteLine("2. Registrarse");
                    WriteLine("3. Salir");
                    Write("Ingrese una opción : ");
                    string? res = ReadLine();

                    if (res == null)
                    {
                        throw new Exception("Opción inválida");
                    }

                    int opcion = int.Parse(res);

                    switch (opcion)
                    {
                        case 1:
                            login();
                            break;
                        case 2:
                            register();
                            break;
                        case 3:
                            exit = true;
                            break;
                        default:
                            WriteLine("Opción inválida");
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    WriteLine("\nError: " + ex.Message);
                    Write("Presione una tecla para continuar...");
                    Read();
                }
            } while (!exit);
        }
    }
}