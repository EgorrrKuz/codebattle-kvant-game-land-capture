using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot
    {
        public int X_Bot { get; set; }
        public int Y_Bot { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Bot(int y, int x, string email, string pass)
        {
            this.Y_Bot = y;
            this.X_Bot = x;
            this.Email = email;
            this.Password = pass;
        }
    }
}
