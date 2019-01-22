using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Projekt
{
    [HubName("AutorskiHub")]
    public class MyHub1 : Hub
    {
        [HubMethodName("send")]
        public void Send(string cont)
        {

            Clients.All.showMessage(cont);
        }

    }
}