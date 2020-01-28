using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using SignalR_backend.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_backend.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IHubContext<UsersHub, IUsersHub> hub;
        private readonly ClientConnection requestInformation;

        public UserController(IHubContext<UsersHub, IUsersHub> hub, ClientConnection requestInformation)
        {
            this.hub = hub;
            this.requestInformation = requestInformation;
        }

        [HttpGet]
        public async Task<int> GetRandomNumber([FromQuery]string userId, [FromQuery]bool sendAllClients)
        {
            var random = new Random().Next();

            if (sendAllClients)
            {
                await hub.Clients.All.NotifyUser(random);
                return random;
            }

            requestInformation.UserConnectionsDictionary.TryGetValue(userId, out List<string> connectionsIds);
            await hub.Clients.Clients(connectionsIds).NotifyUser(random);

            return random;
        }
    }
}
