using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTickets.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EventTickets.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SederController : ControllerBase
    {
      
        [HttpPost]
        public IActionResult SendTicket([FromBody] Tickets ticket)
        {
            string art = Newtonsoft.Json.JsonConvert.SerializeObject(ticket);
            //envio al hub



            return Ok(new { resp = " Enviado satisfactoriamente" });
        }

    }
}
