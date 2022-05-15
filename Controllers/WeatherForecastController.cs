using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmptyWebApiWithDbContext.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly DataBaseContext _dbContext;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataBaseContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    private readonly ILogger<WeatherForecastController> _logger;


    [HttpPost]
    public async Task<IActionResult> Post()
    {
        try
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.Date = DateTime.Now;
            forecast.Summary = "sasan summury";
            forecast.TemperatureC = 100;
            await _dbContext.WeatherForecasts.AddAsync(forecast);
            int result = await _dbContext.SaveChangesAsync();
            if (result <= 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        catch (System.Exception e)
        {
            return BadRequest(e.ToString());
        }


    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var forecast = await _dbContext.WeatherForecasts.ToListAsync();
        return Ok(forecast);
    }


}
