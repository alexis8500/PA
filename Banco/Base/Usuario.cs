using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Usuario
{
    public uint nCuenta;
    public string? nombre;
    public string? apellido;
    public DateOnly nacimiento;
    private uint nip { get; set; }

    public bool validNip(uint nip)
    {
        if (nip == this.nip)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setNip(uint nip)
    {
        this.nip = nip;
        WorkWithFiles();
    }

    public Usuario(uint nCuenta, string? nombre, string? apellido, DateOnly nacimiento)
    {
        this.nCuenta = nCuenta;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nacimiento = nacimiento;
    }

    public void WorkWithFiles()
    {
        string dir = Combine(CurrentDirectory, "Datos", "Usuarios");
        CreateDirectory(dir);

        string textFile = Combine(dir, "Usuarios.txt");

        if (File.Exists(textFile))
        {
            File.AppendAllText(textFile, $"num.Cuenta: {nCuenta}, Nombres: {nombre}, Apellidos: {apellido}, Nacimiento: {nacimiento}\n");
        }
        else
        {
            File.WriteAllText(textFile, $"num.Cuenta: {nCuenta}, Nombres: {nombre}, Apellidos: {apellido}, Nacimiento: {nacimiento}\n");
        }

    }

}