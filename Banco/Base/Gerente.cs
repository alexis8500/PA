using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
public class Gerente
{
    public uint nEmpleado;
    private string? masterKey;

    public void setMasterKey(string? master)
    {
        this.masterKey = master;
        WorkWithFiles();

    }

    public bool validMasterKey(string? master)
    {
        if (master == this.masterKey)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Gerente(uint nEmpleado)
    {
        this.nEmpleado = nEmpleado;
    }

        public void WorkWithFiles()
    {
        string dir = Combine(CurrentDirectory, "Datos", "Gerentes");
        CreateDirectory(dir);

        string textFile = Combine(dir, "Gerentes.txt");

        if (File.Exists(textFile))
        {
            File.AppendAllText(textFile, $"num.Empleado: {nEmpleado}, masterKey: {masterKey}\n");
        }
        else
        {
            File.WriteAllText(textFile, $"num.Empleado: {nEmpleado}, masterKey: {masterKey}\n");
        }

    }
}