using System;
using static System.Console;

namespace Banco2
{
    partial class Program
    {
        public static void user(Models.Usuario usuario)
        {
            bool salir = false;
            do
            {
                try
                {
                    WriteLine("\n\tBanco de Préstamos");
                    WriteLine($"Saldo: ${usuario.Saldo}");
                    WriteLine("1.Pedir préstamo");
                    WriteLine("2.Ver historial de pagos");
                    WriteLine("3.Ver préstamo activo");
                    WriteLine("4.Salir");
                    Write("Ingrese una opción: ");
                    string? opcion = ReadLine();

                    if (opcion == null)
                    {
                        throw new Exception("Opción inválida");
                    }

                    switch (opcion)
                    {
                        case "1":
                            // pedirPrestamo(usuario);
                            break;
                        case "2":
                            verHistorial(usuario);
                            break;
                        case "3":
                            verPrestamoActivo(usuario);
                            break;

                        case "4":
                            salir = true;
                            break;
                        default:
                            throw new Exception("Opción inválida");
                    }
                }
                catch (System.Exception ex)
                {
                    WriteLine("\nError: " + ex.Message);
                    Write("Presione una tecla para continuar...");
                    Read();
                }
            } while (!salir);
        }

        public static void verPrestamoActivo(Models.Usuario usuario)
        {
            try
            {
                var Prestamo = new Models.Prestamo();
                var prestamo = usuario.verPrestamoActivo(usuario);

                if (prestamo is Exception)
                {
                    throw (Exception)prestamo;
                }

                if (prestamo is Models.Prestamo)
                {
                    WriteLine("\nPréstamo activo");
                    WriteLine($"Monto: ${((Models.Prestamo)prestamo).Cantidad}");
                    WriteLine($"Fecha de inicio: {((Models.Prestamo)prestamo).FechaSolicitud}");
                    WriteLine($"Fecha de vencimiento: {((Models.Prestamo)prestamo).FechaLiquidacion}");
                    WriteLine($"Tasa: {((Models.Prestamo)prestamo).Interes} %");
                    WriteLine($"Plazo: {((Models.Prestamo)prestamo).Meses}");
                    WriteLine($"Pago por mes: {((Models.Prestamo)prestamo).PagoMes}");
                    WriteLine($"Estado: {((Models.Prestamo)prestamo).Activo}");
                    Write("Presione una tecla para continuar...");
                    Read();
                }
            }
            catch (System.Exception ex)
            {
                WriteLine("\nError: " + ex.Message);
                Write("Presione una tecla para continuar...");
                Read();
            }
        }

        public static void verHistorial(Models.Usuario usuario)
        {
            try
            {
                using (var db = new Models.bancoContext())
                {
                    var Prestamo = new Models.Usuario();
                    var prestamo = usuario.verHistorial(usuario.Id);

                    if (prestamo is Exception)
                    {
                        throw (Exception)prestamo;
                    }

                    if (prestamo is List<Models.Pago>)
                    {
                        WriteLine("\nHistorial de pagos");
                        int i = 1;
                        int j = 1;
                        int id = 0;
                        foreach (var pago in (List<Models.Pago>)prestamo)
                        {
                            var presta = db.Prestamos.Where(p => p.Id == pago.PrestamoId).FirstOrDefault();

                            if (presta == null)
                            {
                                throw new Exception("Error al obtener el prestamo");
                            }

                            WriteLine($"Folio Prestamo: {pago.PrestamoId} .- Cantidad: {pago.Cantidad}$ Numero de pago: ({j} de {presta.Meses}) Fecha de solicitud: {presta.FechaSolicitud} Fecha de liquidacion: {presta.FechaLiquidacion}");
                            if (i == 1)
                            {
                                id = pago.PrestamoId;
                                j++;
                            }
                            else if (id == pago.PrestamoId)
                            {
                                j++;
                            }
                            else
                            {
                                j = 1;
                                id = pago.PrestamoId;
                            }

                            i++;

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

        public static void ChangeStatus()
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