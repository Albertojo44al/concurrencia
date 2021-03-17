using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.UI.Hubs
{
    public class payment : Hub
    {

        public Task NotificarPago(string mensaje)
        {
            return Clients.All.SendAsync("processPayment", mensaje);
        }
    }
}
