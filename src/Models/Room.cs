using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat.src.Models
{
    public enum ConnectionStatus
    {
        NotConnected = 0,
        Connected = 1,
        Reconnecting = 3,
        Disconnected = 4,
        Kicked = 5,
        Banned = 6
    }

    public class Room
    {
        public String RoomName { set; get; }

        public string Nick { set; get; }

        public ConnectionStatus ConnectionStatus { set; get; }

        public bool GreenRoom { set; get; }

    }
}
