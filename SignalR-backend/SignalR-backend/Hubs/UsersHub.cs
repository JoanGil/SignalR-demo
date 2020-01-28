using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

using SignalR_backend.Models;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_backend
{
    public interface IUsersHub
    {
        Task NotifyUser(int number);
    }

    public class UsersHub : Hub<IUsersHub>
    {
        private readonly ClientConnection clientConnection;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsersHub(ClientConnection clientConnection, IHttpContextAccessor httpContextAccessor)
        {
            this.clientConnection = clientConnection;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userId = httpContextAccessor.HttpContext.Request.Query["userId"].ToString();
            clientConnection.UserConnectionsDictionary.AddOrUpdate(userId, (str1) => new List<string> { connectionId }, (str1, str2) => { str2.Add(connectionId); return str2; });

            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = clientConnection.UserConnectionsDictionary.Where(d => d.Value.Any(i => i == Context.ConnectionId)).Select(d => d.Key).FirstOrDefault();
            clientConnection.UserConnectionsDictionary.TryRemove(userId, out List<string> connectionIds);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
