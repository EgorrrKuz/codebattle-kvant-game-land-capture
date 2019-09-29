using System;
using CodeBattle.PointWar.Server.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text;
using MimeKit.Cryptography;

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

        public Player Get(string email) =>
            _players.Find<Player>(player => player.Email == email).FirstOrDefault();
        
        public Player Create(Player player)
        {
            player.Password = Md5Hash(player.Password);
            
            _players.InsertOne(player);
            return player;
        }

        public void Update(string id, Player playerIn) =>
            _players.ReplaceOne(player => player.ID == id, playerIn);

        public void Remove(Player playerIn) =>
            _players.DeleteOne(player => player.ID == playerIn.ID);

        public void Remove(string id) => 
            _players.DeleteOne(player => player.ID == id);

        public static string Md5Hash(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);

                return hash;
            }
        }
        
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}