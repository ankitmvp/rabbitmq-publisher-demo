using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Core.DependencyInjection.Services;

namespace rabbitmq_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IQueueService RmqService;
        public WeatherForecastController(IQueueService rmqService)
        {
            RmqService = rmqService;
        }

        [HttpPost]
        [Route("PublishMessage")]
        public async Task<IActionResult> PublishMessage([FromQuery] string message)
        {
            await RmqService.SendAsync(@object: message, exchangeName: "demoexchange", routingKey: "demokey");
            return Ok("Message publised.");
        }
    }
}