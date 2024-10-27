using Xunit;
using CalculadoraNewTalents.Models;

namespace TestNewTalents;

public class CalculadoraTests
{

    private readonly Calculadora _calc;

    public CalculadoraTests()
    {
        _calc = new Calculadora("02/02/2020");
    }

    [Theory]
    [InlineData(1,2,3)]
    [InlineData(4,5,9)]
    public void TestSomar(int val1, int val2, int res)
    {
        int resultCalc = _calc.Somar(val1,val2);

        Assert.Equal(res, resultCalc);
    }

    [Theory]
    [InlineData(2,1,1)]
    [InlineData(6,2,4)]
    public void TestSubtrair(int val1, int val2, int res)
    {
        int resultCalc = _calc.Subtrair(val1,val2);

        Assert.Equal(res, resultCalc);
    }

    [Theory]
    [InlineData(1,2,2)]
    [InlineData(4,5,20)]
    public void TestMultiplicar(int val1, int val2, int res)
    {
        int resultCalc = _calc.Multiplicar(val1,val2);

        Assert.Equal(res, resultCalc);
    }

    [Theory]
    [InlineData(4,2,2)]
    [InlineData(20,4,5)]
    public void TestDividir(int val1, int val2, int res)
    {
        int resultCalc = _calc.Dividir(val1,val2);

        Assert.Equal(res, resultCalc);
    }


    [Fact]
    public void TestDividirPorZero()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calc.Dividir(3,0)
        );
    }

    [Fact]
    public void TestHistorico()
    {
        _calc.Somar(1,2);
        _calc.Somar(2,8);
        _calc.Somar(3,7);
        _calc.Somar(4,1);

        var list = _calc.Historico();

        Assert.NotEmpty(list);

        Assert.Equal(3, list.Count);
    }
}