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
        [JsonProperty("Active")]
        public bool Active { get; set; }
        [JsonProperty("API")]
        public bool API { get; set; }
        [JsonProperty("Email")]
        public bool Email { get; set; }

        public string Serialize { get; set; }

        public Point(int _y, int _x, string _API, string _Email)
        {
            this.Y_Point = _y;
            this.X_Point = _x;
            this.API = _API;
            this.Email = _Email;
        }

        public bool IsPoint(int y_point, int x_point)
        {
            if (y_point == Y_Point || x_point == X_Point) return true;
            return false;
        }
    }
}