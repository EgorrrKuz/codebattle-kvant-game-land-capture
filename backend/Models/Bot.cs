using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }
        public string API { get; }
        public string Email { get; }

        public Bot(int _y, int _x, string _API, string _Email)
        {
            this.Y_Bot = _y;
            this.X_Bot = _x;
            this.API = _API;
            this.Email = _Email;
        }
    }
}
