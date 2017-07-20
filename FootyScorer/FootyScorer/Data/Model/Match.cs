using System;
namespace FootyScorer.Data.Model
{
    public class Match : DatabaseMobileBase
    {
        public string AwayTeam { get; set; }

        public string HomeTeam { get; set; }

        public DateTime Date { get; set; }

        public string Venue { get; set; }

        public int Round { get; set; }

        public Guid AwayScore { get; set; }

        public Guid HomeScore { get; set; }
    }
}
