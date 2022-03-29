namespace PeopleLibrary;
//acces modifier
//public, private, protected
// private protected, protected protected, public protected
using System.Collections;// List<T>, Tuple<>, Dictionary<>
public partial class People
{
    // 6 pilares POO: encapsulacion, agregacion, herencia, abstraccion, polimorfism
    //field
     //private string FirstName;


    /* public string GetFirstName ()
     {
        return FirstName;
     }*/

    //prop
    public string FirstName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    public VaccineApplied vaccine;

    public List<People> Children = new List<People>();

    //tupla permite manejar tipos de datos compuestos
    public (string Name , int Number) GetFruit()
    {
        return ("Apple", 5);
    }


}


