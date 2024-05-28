namespace FC24StatsWebApp.Models
{
    public class PlayerViewModel
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int TotalPoints { get; set; }
        public int FirstPlaceCount { get; set; }
        public int SecondPlaceCount { get; set; }
        public int ThirdPlaceCount { get; set; }
        public int OtherPlaceCount { get; set; }
    }
}
