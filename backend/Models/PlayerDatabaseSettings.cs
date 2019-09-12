namespace CodeBattle.PointWar.Server.Models
{
    public class PlayersDatabaseSettings : IPlayersDatabaseSettings
    {
        public string PlayersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPlayersDatabaseSettings
    {
        string PlayersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}