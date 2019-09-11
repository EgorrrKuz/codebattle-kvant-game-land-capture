using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }
        public string Email_Player { get; set; }
        public string Pass_Player { get; set; }
        public string API_Key { get; set; }

        public Bot(int y, int x, string email, string pass, string api)
        {
            this.Y_Bot = y;
            this.X_Bot = x;
            this.Email_Player = email;
            this.Pass_Player = pass;
            this.API_Key = api;
        }
    }
}
