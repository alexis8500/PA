using System;
using static System.Console;
namespace Banco
{
    public partial class Program
    {
        static void Interfaz()
        {
            try
            {
                bool end = false;
                do
                {
                    WriteLine();
                    WriteLine($"Quien solicita??");
                    WriteLine();
                    WriteLine($"1. Usuario");
                    WriteLine($"2. Empleado");
                    WriteLine($"3. Gerente");
                    WriteLine($"4. Salir");
                    WriteLine();
                    Write($"Opcion: ");
                    string? res = ReadLine();

                    Int16 answer = Int16.Parse(res);

                    if (answer <= 0)
                    {
                        WriteLine($"No se pueden ingresar numeros negativos, ingresa una opcion correcta 1-4");
                    }

                    switch (answer)
                    {
                        case 1:

                            Write($"Ingresa tu Numero de Cuenta: ");
                            res = ReadLine();
                            uint nCuenta = uint.Parse(res);
                            IEnumerable<Usuario> users = usuarios.Where(Usuario => Usuario.nCuenta == nCuenta);
                            if (users.LongCount() == 0)
                            {
                                WriteLine($"ese numero de cuenta no existe");
                                return;
                            }

                            Write($"Ingresa tu NIP: ");
                            res = ReadLine();
                            uint nip = uint.Parse(res);
                            if (users.ElementAt(0).nip == nip)
                            {
                                WriteLine();
                                WriteLine($"1. Pedir Prestamo");
                                WriteLine($"2. Historial de prestamos");
                                Write($"Selecciona una opcion: ");
                                res = ReadLine();

                                switch (int.Parse(res))
                                {
                                    case 1:
                                        CrearPrestamo(nCuenta);
                                        break;
                                    case 2:
                                        Historial(nCuenta);
                                        break;
                                    default:
                                        break;
                                }

                            }
                            else
                            {
                                WriteLine($"ese no es tu nip puto");
                            }
                            break;

                        case 2:
                            {
                                Write("\nIngresa tu numero de cuenta : ");
                                res = ReadLine();
                                uint nempleado = uint.Parse(res);
                                IEnumerable<Empleado> workers = empleados.Where(empleado => empleado.nEmpleado == nempleado);
                                if (workers.LongCount() == 0)
                                {
                                    WriteLine("No existe ese numero de empleado");
                                    return;
                                }

                                WriteLine("1. Crear un usuario");
                                WriteLine("2. Crear un empleado");
                                Write("Opcion : ");
                                res = ReadLine();

                                switch (int.Parse(res))
                                {
                                    case 1:
                                        CrearUsuario();
                                        break;
                                    case 2:
                                        crear_empleado();
                                        break;
                                    default:
                                        break;
                                }


                            }
                            break;

                        case 3:
                            {
                                Write("\nIngresa tu numero de cuenta : ");
                                res = ReadLine();
                                uint ngerente = uint.Parse(res);
                                IEnumerable<Gerente> managers = gerentes.Where(gerente => gerente.nEmpleado == ngerente);
                                if (managers.LongCount() == 0)
                                {
                                    WriteLine("No existe ese numero de gerente");
                                    return;
                                }
                                Write("\n ingresa tu master key : ");
                                res = ReadLine();
                                if (managers.ElementAt(0).masterKey == res)
                                {
                                    WriteLine("1. Crear un usuario");
                                    WriteLine("2. Crear un empleado");
                                    WriteLine("3. Crear un gerente");
                                    Write("Opcion : ");
                                    res = ReadLine();

                                    switch (int.Parse(res))
                                    {
                                        case 1:
                                            CrearUsuario();
                                            break;
                                        case 2:
                                            crear_empleado();
                                            break;
                                        case 3:
                                            crear_gerente();
                                            break;  
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    WriteLine("No es tu master key");
                                }
                            }
                            break;

                        case 4:
                            {
                                end = true;
                            }
                            break;

                        default:
                            break;
                    }
                } while (end == false);
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                WriteLine($"Ingresa una opcion correcta");
                return;
            }

        }
    }
}