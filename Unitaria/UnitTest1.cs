using Xunit;
using CardinalUnit;

namespace UnitTest1;

public class UnitTest1
{
[Fact]
  public void NotParse()
  {
    string num = "b";
    string[] expected = { "No se puede parsear" };
    Cardinalidad car = new();

    string[] actual = car.runCardinal(num);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void Negativo()
  {
    string num = "-1";
    string[] expected = { "No numeros negativos" };
    Cardinalidad car = new();

    string[] actual = car.runCardinal(num);

    Assert.Equal(expected, actual);
  }

    [Fact]
  public void Cardinal20()
  {
    string num = "20";
    string[] expected = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th" };
    Cardinalidad car = new();

    string[] actual = car.runCardinal(num);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void CardinalTest()
  {
    string num = "2";
    string[] expected = { "1st", "2nd" };
    Cardinalidad car = new();

    string[] actual = car.runCardinal(num);

    Assert.Equal(expected, actual);
  }
}