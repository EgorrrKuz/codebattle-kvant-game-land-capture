using CodeBattle.PointWar.Server.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Services
{
    public class BotService
    {
        private readonly IMongoCollection<Bot> _bots;

        public BotService(IBotsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bots = database.GetCollection<Bot>(settings.BotsCollectionName);
        }

        public List<Bot> Get() =>
            _bots.Find(bot => true).ToList();


        public Bot Get_from_email(string email) =>
            _bots.Find<Bot>(bot => bot.Email_Player == email).FirstOrDefault();

        public Bot Create(Bot bot)
        {
            _bots.InsertOne(bot);
            return bot;
        }

        public void Update(string email, Bot botIn) =>
            _bots.ReplaceOne(bot => bot.Email_Player == email, botIn);

        public void Remove(Bot botIn) =>
            _bots.DeleteOne(bot => bot.Email_Player == botIn.Email_Player);

        public void Remove(string email) =>
            _bots.DeleteOne(bot => bot.Email_Player == email);
    }
}