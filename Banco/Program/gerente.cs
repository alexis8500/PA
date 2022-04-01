using System;
using static System.Console;
namespace Banco
{
    public partial class Program
    {
        static void crear_gerente()
        {
            try
            {
                Write("\nIngresa el numero de gerente : ");
                string? ngerente = ReadLine();
                uint num_gerente = uint.Parse(ngerente);

                IEnumerable<Empleado> empleados = Program.empleados.Where(empleado => empleado.nEmpleado == num_gerente);
                if (empleados.LongCount() != 0)
                {
                    WriteLine("Ese numero de empleado ya existe");
                    return;
                }
                IEnumerable<Gerente> gerenteCheck = Program.gerentes.Where(gerenteLista => gerenteLista.nEmpleado == num_gerente);
                if (empleados.LongCount() != 0)
                {
                    WriteLine("Ese numero de empleado ya existe");
                    return;
                }

                Write("Ingresa la contraseña maestra : ");
                string? masterKey = ReadLine();
                WriteLine();
                Gerente gerente = new Gerente(num_gerente, masterKey);
                gerentes.Add(gerente);
                GerenteJsonSerialization(gerentes);
                GerenteXmlSerialization(gerentes);

                WriteLine("El gerente se ha creado satisfactoriamente");
            }
            catch (System.Exception ex)
            {
                WriteLine($"{ex.Message}");
                return;
            }
        }
    }
}