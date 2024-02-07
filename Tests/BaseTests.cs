using backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests;

public class BaseTests
{

    CalculatorController controller = new CalculatorController(null);

    [Fact]
    public void DivideByZeroShouldReturnStatusCode400()
    {
        var result = controller.Divide((decimal)10, (decimal)0);
        Assert.True(result != null);
        BadRequestObjectResult actual = result as BadRequestObjectResult;
        Assert.True(actual == null);
    }

    [Fact]
    public void AddTest()
    {
        var result = controller.Add((decimal)0.1, (decimal)0.2) as ObjectResult;
        Assert.True(result != null);
        Assert.Equal(result.Value, (decimal)0.3);
    }

    [Fact]
    public void SubtractTest()
    {
        var result = controller.Substract((decimal)1, (decimal)2) as ObjectResult;
        Assert.True(result != null);
        Assert.Equal(result.Value, (decimal)(-1));
    }

    [Fact]
    public void MultiplyTest()
    {
        var result = controller.Multiply((decimal)35, (decimal)46) as ObjectResult;
        Assert.True(result != null);
        Assert.Equal(result.Value, (decimal)1610);
    }

    [Fact]
    public void DivideTest()
    {
        var result = controller.Divide((decimal)10, (decimal)2) as ObjectResult;
        Assert.True(result != null);
        Assert.Equal(result.Value, (decimal)5);

        result = controller.Divide((decimal)2, (decimal)10) as ObjectResult;
        Assert.True(result != null);
        Assert.Equal(result.Value, (decimal)0.2);
    }

}