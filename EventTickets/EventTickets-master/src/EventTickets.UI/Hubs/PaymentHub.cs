using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.UI.Hubs
{
    public class PaymentHub: Hub
    {

        public async Task SendPaymente(string user, String message)
        {
            await Clients.All.SendAsync("pago completado", user, message);
        }

    }
}
