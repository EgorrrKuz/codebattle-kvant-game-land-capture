using CodeBattle.PointWar.Server.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Services
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _players;

        public PlayerService(IPlayersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _players = database.GetCollection<Player>(settings.PlayersCollectionName);
        }

        public List<Player> Get() =>
            _players.Find(player => true).ToList();

        public Player Get(string id) =>
            _players.Find<Player>(player => player.ID == id).FirstOrDefault();
        
        public Player Get_from_email(string email) =>
            _players.Find<Player>(player => player.Email == email).FirstOrDefault();

        public Player Create(Player player)
        {
            _players.InsertOne(player);
            return player;
        }

        public void Update(string id, Player playerIn) =>
            _players.ReplaceOne(player => player.ID == id, playerIn);

        public void Remove(Player playerIn) =>
            _players.DeleteOne(player => player.ID == playerIn.ID);

        public void Remove(string id) => 
            _players.DeleteOne(player => player.ID == id);
    }
}