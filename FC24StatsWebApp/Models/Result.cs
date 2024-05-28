namespace FC24StatsWebApp.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public int PlayerID { get; set; }
        public int TournamentID { get; set; }
        public int Place { get; set; }

        // Właściwość nawigacyjna do gracza
        public Player? Player { get; set; }
        public Tournament? Tournament { get; set; }
    }
}
