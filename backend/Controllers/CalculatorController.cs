using System.Numerics;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [Route("add")]
    [HttpPost(Name = "add")]
    // if using float or double, you can get wrong results like 0.1 + 0.2 = 0.30000000000000004
    public IActionResult Add(decimal x, decimal y)
    {
        return Ok(x + y);
    }

    [Route("substract")]
    [HttpPost(Name = "substract")]
    public IActionResult Substract(decimal x, decimal y)
    {
        return Ok(x - y);
    }

    [Route("multiply")]
    [HttpPost(Name = "multiply")]
    public IActionResult Multiply(decimal x, decimal y)
    {
        return Ok(x * y);
    }

    [Route("divide")]
    [HttpPost(Name = "divide")]
    public IActionResult Divide(decimal x, decimal y)
    {
        if(y == 0){
            return BadRequest();
        }
        return Ok(x / y);
    }
}
