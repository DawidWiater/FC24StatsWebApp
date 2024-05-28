namespace FC24StatsWebApp.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
