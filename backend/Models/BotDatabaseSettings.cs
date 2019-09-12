namespace CodeBattle.PointWar.Server.Models
{
    public class BotsDatabaseSettings : IBotsDatabaseSettings
    {
        public string BotsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBotsDatabaseSettings
    {
        string BotsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}