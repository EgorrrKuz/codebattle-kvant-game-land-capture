using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Models
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string ID { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Email")]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Password")]
        [JsonProperty("Password")]
        public string Password { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        [BsonElement("Score")]
        [JsonProperty("Score")]
        public int Score { get; set; }

        // API всех ботов привязанных к одному игроку в одном массиве
        [BsonRepresentation(BsonType.Array)]
        [BsonElement("API_Key")]
        [JsonProperty("API_Key")]
        public List<string> API_Key { get; set; }
    }
}
