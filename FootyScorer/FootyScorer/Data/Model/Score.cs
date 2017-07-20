using System;
namespace FootyScorer.Data.Model
{
    public class Score : DatabaseMobileBase
    {
        public int QuarterOneGoals { get; set; }

        public int QuarterOnePoints { get; set; }

		public int QuarterTwoGoals { get; set; }

		public int QuarterTwoPoints { get; set; }

		public int QuarterThreeGoals { get; set; }

		public int QuarterThreePoints { get; set; }

		public int QuarterFourGoals { get; set; }

		public int QuarterFourPoints { get; set; }
    }
}
