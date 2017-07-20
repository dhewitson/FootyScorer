using System;

namespace FootyScorer.ViewModel
{
    public class MatchViewModel : ViewModelBase
    {
        private string _homeTeam;
        private string _awayTeam;
        private string _round;
        private string _venue;
        
        /// <summary>
        /// Gets or sets the home team.
        /// </summary>
        /// <value>The home team.</value>
        public string HomeTeam 
        {
            get { return _homeTeam; }
            set 
            {
                _homeTeam = value;
                OnPropertyChanged(nameof(HomeTeam));
            }
        }

        /// <summary>
        /// Gets or sets the away team.
        /// </summary>
        /// <value>The away team.</value>
        public string AwayTeam
		{
			get { return _awayTeam; }
			set
			{
				_awayTeam = value;
				OnPropertyChanged(nameof(AwayTeam));
			}
		}

        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        /// <value>The round.</value>
        public string Round
		{
			get { return _round; }
			set
			{
				_round = value;
				OnPropertyChanged(nameof(Round));
			}
		}

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the date as text.
        /// </summary>
        /// <value>The date text.</value>
        public string DateText => Date.ToString("ddd MMM yyyy, HH:mm");

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>The venue.</value>
		public string Venue
		{
			get { return _venue; }
			set
			{
				_venue = value;
				OnPropertyChanged(nameof(Venue));
			}
		}

        /// <summary>
        /// Gets or sets the away score.
        /// </summary>
        /// <value>The away score.</value>
        public ScoreViewModel AwayScore { get; set; }

        /// <summary>
        /// Gets or sets the home score.
        /// </summary>
        /// <value>The home score.</value>
        public ScoreViewModel HomeScore { get; set; }
    }
}
