using System;

namespace FootyScorer.ViewModel
{
    public class ScoreViewModel : ViewModelBase
    {
        private int _quarterOneGoals;
        private int _quarterOnePoints;
		private int _quarterTwoGoals;
		private int _quarterTwoPoints;
		private int _quarterThreeGoals;
		private int _quarterThreePoints;
		private int _quarterFourGoals;
		private int _quarterFourPoints;

        /// <summary>
        /// Gets or sets the quarter one goals.
        /// </summary>
        /// <value>The quarter one goals.</value>
		public int QuarterOneGoals
		{
			get { return _quarterOneGoals; }
			set
			{
				_quarterOneGoals = value;
				OnPropertyChanged(nameof(QuarterOneGoals));
			}
		}

        /// <summary>
        /// Gets or sets the quarter one points.
        /// </summary>
        /// <value>The quarter one points.</value>
		public int QuarterOnePoints
		{
			get { return _quarterOnePoints; }
			set
			{
				_quarterOnePoints = value;
				OnPropertyChanged(nameof(QuarterOnePoints));
			}
		}

        /// <summary>
        /// Gets or sets the quarter two goals.
        /// </summary>
        /// <value>The quarter two goals.</value>
		public int QuarterTwoGoals
		{
			get { return _quarterTwoGoals; }
			set
			{
				_quarterTwoGoals = value;
				OnPropertyChanged(nameof(QuarterTwoGoals));
			}
		}

        /// <summary>
        /// Gets or sets the quarter two points.
        /// </summary>
        /// <value>The quarter two points.</value>
		public int QuarterTwoPoints
		{
			get { return _quarterTwoPoints; }
			set
			{
				_quarterTwoPoints = value;
				OnPropertyChanged(nameof(QuarterTwoPoints));
			}
		}

        /// <summary>
        /// Gets or sets the quarter three goals.
        /// </summary>
        /// <value>The quarter three goals.</value>
		public int QuarterThreeGoals
		{
			get { return _quarterThreeGoals; }
			set
			{
				_quarterThreeGoals = value;
				OnPropertyChanged(nameof(QuarterThreeGoals));
			}
		}

        /// <summary>
        /// Gets or sets the quarter three points.
        /// </summary>
        /// <value>The quarter three points.</value>
		public int QuarterThreePoints
		{
			get { return _quarterThreePoints; }
			set
			{
				_quarterThreePoints = value;
				OnPropertyChanged(nameof(QuarterThreePoints));
			}
		}

        /// <summary>
        /// Gets or sets the quarter four goals.
        /// </summary>
        /// <value>The quarter four goals.</value>
		public int QuarterFourGoals
		{
			get { return _quarterFourGoals; }
			set
			{
				_quarterFourGoals = value;
				OnPropertyChanged(nameof(QuarterFourGoals));
			}
		}

        /// <summary>
        /// Gets or sets the quarter four points.
        /// </summary>
        /// <value>The quarter four points.</value>
		public int QuarterFourPoints
		{
			get { return _quarterFourPoints; }
			set
			{
				_quarterFourPoints = value;
				OnPropertyChanged(nameof(QuarterFourPoints));
			}
		}

        /// <summary>
        /// Gets the quarter one score.
        /// </summary>
        /// <value>The quarter one score.</value>
        public string QuarterOneScore => $"{QuarterOneGoals}.{QuarterOnePoints}.{QuarterOneTotal}";

        /// <summary>
        /// Gets the quarter two score.
        /// </summary>
        /// <value>The quarter two score.</value>
        public string QuarterTwoScore => $"{QuarterTwoGoals}.{QuarterTwoPoints}.{QuarterTwoTotal}";

        /// <summary>
        /// Gets the quarter three score.
        /// </summary>
        /// <value>The quarter three score.</value>
        public string QuarterThreeScore => $"{QuarterThreeGoals}.{QuarterThreePoints}.{QuarterThreeTotal}";

        /// <summary>
        /// Gets the quarter four score.
        /// </summary>
        /// <value>The quarter four score.</value>
        public string QuarterFourScore => $"{QuarterFourGoals}.{QuarterFourPoints}.{QuarterFourTotal}";

        /// <summary>
        /// Gets the total score long.
        /// </summary>
        /// <value>The total score long.</value>
        public string TotalScoreLong => $"{(QuarterOneGoals + QuarterTwoGoals + QuarterThreeGoals + QuarterFourGoals)}.{(QuarterOnePoints + QuarterTwoPoints + QuarterThreePoints + QuarterFourPoints)}.{TotalScore}";

        /// <summary>
        /// Gets the quarter one total.
        /// </summary>
        /// <value>The quarter one total.</value>
        public int QuarterOneTotal => (QuarterOneGoals * 6) + QuarterOnePoints;

        /// <summary>
        /// Gets the quarter two total.
        /// </summary>
        /// <value>The quarter two total.</value>
        public int QuarterTwoTotal => (QuarterTwoGoals * 6) + QuarterTwoPoints;

        /// <summary>
        /// Gets the quarter three total.
        /// </summary>
        /// <value>The quarter three total.</value>
        public int QuarterThreeTotal => (QuarterThreeGoals * 6) + QuarterThreePoints;

        /// <summary>
        /// Gets the quarter four total.
        /// </summary>
        /// <value>The quarter four total.</value>
        public int QuarterFourTotal => (QuarterFourGoals * 6) + QuarterFourPoints;


        /// <summary>
        /// Gets the total score.
        /// </summary>
        /// <value>The total score.</value>
        public int TotalScore => QuarterOneTotal + QuarterTwoTotal + QuarterThreeTotal + QuarterFourTotal;
    }
}
