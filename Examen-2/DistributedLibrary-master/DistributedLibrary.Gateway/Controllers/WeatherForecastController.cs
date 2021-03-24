using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace DistributedLibrary.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("book/{bookId}")]

        public async Task<ActionResult> GetBook(Guid isbn)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("send-payment", false, false, false, null);
                        var body = Encoding.UTF8.GetBytes(isbn.ToString());

                        channel.BasicPublish("", "send-payment", null, body);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
