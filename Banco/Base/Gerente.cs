public class Gerente
{
    public uint nEmpleado;
    private string? masterKey;

    public void setMasterKey(string? master)
    {
        this.masterKey = master;
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
}