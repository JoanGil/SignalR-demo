using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SignalR_backend.Models
{
    public class ClientConnection
    {
        public ConcurrentDictionary<string, List<string>> UserConnectionsDictionary { get; set; } = new ConcurrentDictionary<string, List<string>>();
    }
}
