using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CodeBattle.PointWar.Server.Models
{
    public class Bot
    {
        [BsonRepresentation(BsonType.Int64)]
        [BsonElement("X_Bot")]
        [JsonProperty("X_Bot")]
        public int X_Bot { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        [BsonElement("Y_Bot")]
        [JsonProperty("Y_Bot")]
        public int Y_Bot { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Email_Player")]
        [JsonProperty("Email_Player")]
        public string Email_Player { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Pass_Player")]
        [JsonProperty("Pass_Player")]
        public string Pass_Player { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("API_Key")]
        [JsonProperty("API_Key")]
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
