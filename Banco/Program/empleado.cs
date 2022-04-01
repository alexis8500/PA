using System;
using static System.Console;
namespace Banco
{
    public partial class Program
    {
        static void crear_empleado()
        {
            try
            {
                Write("\nIngresa el numero de empleado : ");
                string? nempleado = ReadLine();
                uint num_empleado = uint.Parse(nempleado);

                IEnumerable<Empleado> empleadosCkeck = Program.empleados.Where(empleado => empleado.nEmpleado == num_empleado);
                if (empleados.LongCount() != 0)
                {
                    WriteLine("Ese numero de empleado ya existe");
                    return;
                }
                IEnumerable<Gerente> gerenteCheck = Program.gerentes.Where(gerenteLista => gerenteLista.nEmpleado == num_empleado);
                if (empleados.LongCount() != 0)
                {
                    WriteLine("Ese numero de empleado ya existe");
                    return;
                }

                Write("\nIngresa el nombre : ");
                string? nombre = ReadLine();
                Write("Ingresa el apellido : ");
                string? apellido = ReadLine();
                Write("Ingresa el fecha de nacimiento : ");
                string? fecha = ReadLine();
                WriteLine();
                DateTime fecha_nacimiento = DateTime.Parse(fecha);
                Empleado worker = new Empleado(num_empleado, nombre, apellido, fecha_nacimiento);
                empleados.Add(worker);

                WriteLine("El empleado se ha creado satisfactoriamente");
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return;
            }
        }
    }
}
