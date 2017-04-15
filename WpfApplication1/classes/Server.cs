using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG.classes
{
    public enum ServerType { Auth, Game, Auction, Lobby }
    class Server
    {
        private ServerType _Type;
        private List<object> _Users;
        private bool _Online;
        private string _Name;

        /// <summary>
        /// Name of this Server
        /// </summary>
        public string Name { get { return _Name; } }
        /// <summary>
        /// Server Type of this Server
        /// </summary>
        public ServerType Type { get { return _Type; } }
        /// <summary>
        /// Whether or not the server is online
        /// </summary>
        public string Status { get { return _Online ? "Up" : "Down"; } }
        /// <summary>
        /// Number of players currently connected to this server
        /// </summary>
        public int UsersOnline { get { return _Users.Count; } }

        public Server(ServerType sType, string sName) {
            _Type = sType;
            _Name = sName;
            _Online = true;
            _Users = new List<object>();
        }
    }
}
