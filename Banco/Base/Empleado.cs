using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Empleado
{
    public uint nEmpleado;
    public string? nombre;
    public string? apellido;
    public DateOnly nacimiento;

    public Empleado(uint nEmpleado, string? nombre, string? apellido, DateOnly nacimiento)
    {
        this.nEmpleado = nEmpleado;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nacimiento = nacimiento;
        WorkWithFiles();
    }

        public void WorkWithFiles()
    {
        string dir = Combine(CurrentDirectory, "Datos", "Empleados");
        CreateDirectory(dir);

        string textFile = Combine(dir, "Empleados.txt");

        if (File.Exists(textFile))
        {
            File.AppendAllText(textFile, $"num.Empleado: {nEmpleado}, Nombres: {nombre}, Apellidos: {apellido}, Nacimiento: {nacimiento}\n");
        }
        else
        {
            File.WriteAllText(textFile, $"num.Empleado: {nEmpleado}, Nombres: {nombre}, Apellidos: {apellido}, Nacimiento: {nacimiento}\n");
        }

    }
}