using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Point
    {
        [JsonProperty("X_Point")]
        public int X_Point { get; set; }

        [JsonProperty("Y_Point")]
        public int Y_Point { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("Player_Email")]
        public string Player_Email { get; set; }

        [JsonProperty("Player_Pass")]
        public string Player_Pass { get; set; }

        [JsonProperty("Bot_API")]
        public string Bot_API { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        public string Serialize { get; set; }

        public Point(int x, int y, string email, string pass, string api)
        {
            this.Y_Point = y;
            this.X_Point = x;
            this.Player_Email = email;
            this.Player_Pass = pass;
            this.Bot_API = api;
        }

        public bool IsPoint(int y_point, int x_point)
        {
            if (y_point == Y_Point || x_point == X_Point) return true;
            return false;
        }
    }
}