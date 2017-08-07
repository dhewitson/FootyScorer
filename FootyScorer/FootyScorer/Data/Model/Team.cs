using System;
namespace FootyScorer.Data.Model
{
    public class Team : DatabaseMobileBase
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CompetitionName { get; set; }
    }
}
