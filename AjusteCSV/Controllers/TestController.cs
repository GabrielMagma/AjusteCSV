using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using AjusteCSV.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IHubContext<NotificationHub> _hubContext;
        public TestController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        private async Task AddMessage(bool success, string message)
        {
            await _hubContext.Clients.All.SendAsync("Receive", success, message);
        }

        [HttpPost]
        [Route(nameof(TestController.SendHub))]        
        public async Task<IActionResult> SendHub()
        {
            await AddMessage(true, "Mensaje de prueba desde segundo api");
            return Ok();
           
        }
    }
}
