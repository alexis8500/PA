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
    }
}