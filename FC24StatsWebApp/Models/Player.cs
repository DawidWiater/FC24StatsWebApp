namespace FC24StatsWebApp.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        // Właściwość nawigacyjna do wyników
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
