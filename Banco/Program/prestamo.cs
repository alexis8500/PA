using System;
using static System.Console;
namespace Banco
{
    public partial class Program
    {
        static void CrearPrestamo(uint num_cuenta)
        {
            try
            {
                Write("Ingresa el monto : ");
                string? monto = ReadLine();
                float monto_prestamo = float.Parse(monto);
                Write("Ingresa el plazo (6, 12, 24, 36 meses) : ");
                string? plazo = ReadLine();
                uint plazo_prestamo = uint.Parse(plazo);
                if (plazo_prestamo != 6 && plazo_prestamo != 12 && plazo_prestamo != 24 && plazo_prestamo != 36)
                {
                    WriteLine("No se puede pagar en ese tiempo");
                    return;
                }

                bool approved = validar_prestamos(plazo_prestamo);

                if (!approved)
                {
                    WriteLine("El prestamo no pudo ser aprobado");
                    return;
                }

                WriteLine("El interes es de 15%");
                uint int_interes = 15;
                WriteLine();

                float monto_total = monto_prestamo + (monto_prestamo * (int_interes / 100f));

                float por_mes = monto_total / plazo_prestamo;
                DateTime fecha = DateTime.Now;
                WriteLine($"El pago mensual es de {por_mes}");
                WriteLine($"La fecha del primer pago es {fecha.AddMonths(1):D}");


                Prestamo prestamo = new Prestamo(int_interes, monto_prestamo, plazo_prestamo, num_cuenta);
                prestamos.Add(prestamo);
                PrestamoJsonSerialization(prestamos);
                PrestamoXmlSerialization(prestamos);


                WriteLine("El prestamo se ha generado satisfactoriamente");
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return;
            }
        }

        static void Historial(uint num_cuenta)
        {
            try
            {
                IEnumerable<Prestamo> prestamos = Program.prestamos.Where(prestamo => prestamo.nCuenta == num_cuenta);
                if (prestamos.LongCount() == 0)
                {
                    WriteLine("No tienes prestamos");
                    return;
                }

                WriteLine("\nMonto\t\tPlazo\tInteres\tFecha de creacion");
                foreach (Prestamo prestamo in prestamos)
                {
                    WriteLine($"{prestamo.monto}\t\t{prestamo.tiempo}\t{prestamo.interes}\t{prestamo.fecha_prestamo}");
                }
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return;
            }
        }

        static bool validar_prestamos(uint plazo)
        {
            try
            {
                if (plazo == 6 || plazo == 12)
                {
                    Write("Ingresa numero de empleado : ");
                    string? res = ReadLine();
                    uint num_empleado = uint.Parse(res);
                    IEnumerable<Empleado> workers = empleados.Where(empleado => empleado.nEmpleado == num_empleado);

                    if (workers.LongCount() == 0)
                    {
                        WriteLine("No existe el empleado");
                        return false;
                    }

                    WriteLine("Aprobado");
                    return true;
                }
                else if (plazo == 24 || plazo == 36)
                {
                    Write("Ingresa numero de empleado del gerente : ");
                    string? res = ReadLine();
                    uint num_empleado = uint.Parse(res);
                    IEnumerable<Gerente> managers = gerentes.Where(gerente => gerente.nEmpleado == num_empleado);

                    if (managers.LongCount() == 0)
                    {
                        WriteLine("No existe el gerente");
                        return false;
                    }

                    Write("Ingresa la contraseña maestra: ");
                    res = ReadLine();

                    bool pass = managers.ElementAt(0).masterKey == res;

                    if (!pass)
                    {
                        WriteLine("La contraseña maestra es incorrecta");
                        return false;
                    }

                    WriteLine("Aprobado");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return false;
            }
        }
    }
}
