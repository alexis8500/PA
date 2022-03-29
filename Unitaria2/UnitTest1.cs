using Xunit;
using PrestamoUnit;

namespace Unitaria2;

public class UnitTest2
{
    [Fact]
    public void ErrorMeses()
    {
        string monto = "1000";
        string tiempo = "10";
        string[] expected = { "No se puede pagar en ese tiempo" };
        Banco prestar = new();

        string[] actual = prestar.prestamo(monto, tiempo);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ParseError()
    {
        string monto = "b";
        string tiempo = "100";
        string[] expected = { "No se pudo parsear" };
        Banco prestar = new();

        string[] actual = prestar.prestamo(monto, tiempo);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void prestamo()
    {
        string monto = "5000";
        string tiempo = "12";
        string[] expected = {"El pago mensual es de 479.16666", "La fecha del primer pago es jueves, 7 de abril de 2022" };
        Banco prestar = new();

        string[] actual = prestar.prestamo(monto, tiempo);

        Assert.Equal(expected, actual);
    }
}