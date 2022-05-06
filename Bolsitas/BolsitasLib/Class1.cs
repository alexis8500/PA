namespace BolsitasLib;
public partial class jugadores
{
    public jugadores()
    {

    }
    public jugadores(string Name)
    {
        Fname = Name;
    }

    public string Fname { get; set; }

    public List<int> Boletos = new List<int>();
}
