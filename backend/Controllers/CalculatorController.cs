using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace backend.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{

    private readonly Serilog.Core.Logger _log = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

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
        _log.Information("received request: {x} + {y}, {date}", x, y, DateTime.UtcNow.ToLongTimeString());
        return Ok(x + y);
    }

    [Route("subtract")]
    [HttpPost(Name = "subtract")]
    public IActionResult Subtract(decimal x, decimal y)
    {
        _log.Information("received request: {x} - {y}, {date}", x, y, DateTime.UtcNow.ToLongTimeString());
        return Ok(x - y);
    }

    [Route("multiply")]
    [HttpPost(Name = "multiply")]
    public IActionResult Multiply(decimal x, decimal y)
    {
        _log.Information("received request: {x} * {y}, {date}", x, y, DateTime.UtcNow.ToLongTimeString());
        return Ok(x * y);
    }

    [Route("divide")]
    [HttpPost(Name = "divide")]
    public IActionResult Divide(decimal x, decimal y)
    {
        _log.Information("received request: {x} / {y}, {date}", x, y, DateTime.UtcNow.ToLongTimeString());
        if(y == 0){
            return BadRequest();
        }
        return Ok(x / y);
    }
}
