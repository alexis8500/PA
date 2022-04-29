using System;
using static System.Console;

namespace Banco2
{
    partial class Program
    {
        public static void manager(Models.Gerente gerente)
        {
            bool salir = false;
            do
            {
                WriteLine("\n\tBanco de Préstamos");
                WriteLine("1. Generar empleado");
                WriteLine("2. Pedir Vacaciones");
                WriteLine("3. Aceptar Prestamos");
                WriteLine("4. Generar reportes");
                WriteLine("5. Dar de baja empleados");
                WriteLine("6. Dar de baja usuarios");
                WriteLine("7. Pausar prestamos");
                WriteLine("8. Pedir un prestamo");
                WriteLine("9. Aprobar solicitudes de usuarios");
                WriteLine("10. Generar gerente");
                WriteLine("11. Salir");
                Write("Ingrese una opción: ");
                string? opcion = ReadLine();

                if (opcion == null)
                {
                    throw new Exception("Opción inválida");
                }

                switch (opcion)
                {
                    case "1":
                        generarEmpleado(gerente);
                        break;
                    case "2":
                        //pedirVacaciones(gerente);
                        break;
                    case "3":
                        //aceptarPrestamosGerente(gerente);
                        break;
                    case "4":
                        //generarReportes(gerente);
                        break;
                    case "5":
                        //darDeBajaEmpleados(gerente);
                        break;
                    case "6":
                        //darDeBajaUsuarios(gerente);
                        break;
                    case "7":
                        //pausarPrestamos(gerente);
                        break;
                    case "8":
                        //pedirPrestamoGerente(gerente);
                        break;
                    case "9":
                        //aprobarSolicitudes(gerente);
                        break;
                    case "10":
                        //generarGerente(gerente);
                        break;
                    case "11":
                        salir = true;
                        break;
                    default:
                        WriteLine("Opción inválida");
                        break;
                }
            } while (!salir);
        }

        public static void generarEmpleado(Models.Gerente usuario)
        {
            using (Models.bancoContext db = new())
            {
                var nemployee = new Models.Empleado();
                //Valores ingresados por el Gerente
                WriteLine("Ingrese el primer Nombre");
                string? primerNombre = ReadLine();
                WriteLine("Ingrese el Segundo Nombre (Puede ser nulo)");
                string? segundoNombre = ReadLine();
                //Segundo Nombre, verificacion General
                //Continuacion 
                WriteLine("Ingrese el Primer Apellido");
                string? primerApellido = ReadLine();
                WriteLine("Ingrese el Segundo Apellido");
                string? segundoApellido = ReadLine();
                WriteLine("Ingrese su fecha de nacimiento en este formato dd-mm-yyyy:");
                string? fechaNacimiento = ReadLine();
                WriteLine("Escribe cual sera la contraseña del empleado");
                string? Password = ReadLine();

                if (primerNombre == null || primerApellido == null || segundoApellido == null || fechaNacimiento == null || Password == null)
                {
                    throw new Exception("Falta de datos");
                }

                DateOnly FechaNacimiento = DateOnly.Parse(fechaNacimiento);

                //var newEmpleado = nemployee.Create(primerNombre, segundoNombre, primerApellido, segundoApellido, FechaNacimiento, Password);

                // if (newEmpleado is Exception)
                // {
                //     throw new Exception("Error al crear el empleado");
                // }

                nemployee.PrimerNombre = primerNombre;
                nemployee.SegundoNombre = segundoNombre;
                nemployee.PrimerApellido = primerApellido;
                nemployee.SegundoApellido = segundoApellido;
                nemployee.FechaNacimiento = FechaNacimiento;
                nemployee.Password = Password;

                WriteLine("Persona creada con exito");

                db.Empleados.Add(nemployee);

                db.SaveChanges();

                var ncuenta = new Models.Cuenta();
                ncuenta.NCuentaEmpleado = nemployee.Id;
                ncuenta.Tipo = 2;
                db.Cuentas.Add(ncuenta);
                db.SaveChanges();
            }
        }

        public static void aprobarSolicitudes(Models.Gerente usuario)
        {
            try
            {
                using (Models.bancoContext db = new())
                {
                    var query = db.Solicituds.Where(p => p.Estatus == 1).Join
                    (
                        db.Personas, pSolicitud => pSolicitud.PersonaId, persona => persona.Id, (pSolicitud, persona) => new { pSolicitud, persona }
                    ).ToList();
                    WriteLine("Solicitudes:");
                    if (query.Count is 0)
                    {
                        WriteLine("No Hay Solicitudes Pendientes...");
                    }
                    else
                    {
                        foreach (var item in query)
                        {
                            WriteLine($"Id de la persona: {item.persona.Id} [{item.persona.PrimerNombre} {item.persona.SegundoNombre} {item.persona.PrimerApellido} {item.persona.SegundoApellido}]");
                        }
                        WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Write("ID Persona:");
                        int id = int.Parse(ReadLine());
                        var person = db.Solicituds.Where(u => u.PersonaId == id).FirstOrDefault();
                        if (person.Estatus != 1 || person is null)
                        {
                            WriteLine("Error:Solicitud no encontrada");
                        }
                        else
                        {
                            WriteLine("1-Aprobar\n2-Rechazar");
                            int status = int.Parse(ReadLine());
                            switch (status)
                            {
                                case 1:
                                    {
                                        person.Estatus = 2;
                                        WriteLine("Aprobado!");

                                        var datos = db.Solicituds.Where(p => p.PersonaId == id).Join(
                                            db.Personas, pSolicitud => pSolicitud.PersonaId, persona => persona.Id, (pSolicitud, persona) => new { pSolicitud, persona }
                                        ).FirstOrDefault();


                                        db.SaveChanges();

                                        var user = new Models.Usuario();
                                        var rUser = user.Create(id, datos.persona.PrimerNombre, datos.persona.PrimerApellido, datos.persona.SegundoApellido, datos.persona.FechaNacimiento);
                                        if (rUser is Exception)
                                        {
                                            throw (Exception)rUser;
                                        }

                                        break;
                                    }
                                case 2:
                                    {
                                        person.Estatus = 3;
                                        WriteLine("Denegado!");
                                        db.SaveChanges();
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                WriteLine("\nError: " + ex.Message);
                Write("Presione una tecla para continuar...");
                Read();
            }
        }
    }
}