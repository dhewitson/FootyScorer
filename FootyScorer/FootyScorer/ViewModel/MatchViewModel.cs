using System;

namespace FootyScorer.ViewModel
{
    public class MatchViewModel : ViewModelBase
    {
        private string _homeTeam;
        private string _awayTeam;
        private string _competitionName;
		private string _homeTeamShort;
		private string _awayTeamShort;
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
		/// Gets or sets the home team.
		/// </summary>
		/// <value>The home team.</value>
		public string HomeTeamShort
		{
			get { return _homeTeamShort; }
			set
			{
				_homeTeamShort = value;
				OnPropertyChanged(nameof(HomeTeamShort));
			}
		}

		/// <summary>
		/// Gets or sets the away team short name.
		/// </summary>
		/// <value>The away team.</value>
		public string AwayTeamShort
		{
			get { return _awayTeamShort; }
			set
			{
				_awayTeamShort = value;
				OnPropertyChanged(nameof(AwayTeamShort));
			}
		}

        /// <summary>
        /// Gets or sets the name of the competition.
        /// </summary>
        /// <value>The name of the competition.</value>
		public string CompetitionName
		{
			get { return _competitionName; }
			set
			{
				_competitionName = value;
				OnPropertyChanged(nameof(CompetitionName));
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
                OnPropertyChanged(nameof(RoundNumber));
			}
		}

        public string RoundNumber => Round.Substring(6);

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

		/// <summary>
		/// Gets the date as text.
		/// </summary>
		/// <value>The date text.</value>
		public string ShortDateText => Date.ToString(", d MMM yyyy");


		/// <summary>
		/// Gets the date as text.
		/// </summary>
		/// <value>The date text.</value>
		public string DateText => Date.ToString("ddd, dd MMM yyyy");

        /// <summary>
        /// Gets the long date text.
        /// </summary>
        /// <value>The long date text.</value>
        public string LongDateText => Date.ToString("dddd, dd MMMM yyyy");

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

        /// <summary>
        /// Gets or sets the away team short.
        /// </summary>
        /// <value>The away team short.</value>
        public string AwayTeamTotalShort => AwayScore.TotalScore.ToString();

        /// <summary>
        /// Gets the away team total.
        /// </summary>
        /// <value>The away team total.</value>
        public string AwayTeamTotal => AwayScore.TotalScoreLong;

        /// <summary>
        /// Gets the home team short.
        /// </summary>
        /// <value>The home team short.</value>
        public string HomeTeamTotalShort => HomeScore.TotalScore.ToString();

        /// <summary>
        /// Gets the home team total.
        /// </summary>
        /// <value>The home team total.</value>
        public string HomeTeamTotal => HomeScore.TotalScoreLong;

        /// <summary>
        /// Gets the away team quarter one.
        /// </summary>
        /// <value>The away team quarter one.</value>
        public string AwayTeamQuarterOne => AwayScore.QuarterOneScore;

        /// <summary>
        /// Gets the away team quarter two.
        /// </summary>
        /// <value>The away team quarter two.</value>
        public string AwayTeamQuarterTwo => AwayScore.QuarterTwoScore;

        /// <summary>
        /// Gets the away team quarter three.
        /// </summary>
        /// <value>The away team quarter three.</value>
        public string AwayTeamQuarterThree => AwayScore.QuarterThreeScore;

        /// <summary>
        /// Gets the away team quarter four.
        /// </summary>
        /// <value>The away team quarter four.</value>
        public string AwayTeamQuarterFour => AwayScore.QuarterFourScore;

        /// <summary>
        /// Gets the home team quarter one.
        /// </summary>
        /// <value>The home team quarter one.</value>
		public string HomeTeamQuarterOne => HomeScore.QuarterOneScore;

        /// <summary>
        /// Gets the home team quarter two.
        /// </summary>
        /// <value>The home team quarter two.</value>
		public string HomeTeamQuarterTwo => HomeScore.QuarterTwoScore;

        /// <summary>
        /// Gets the home team quarter three.
        /// </summary>
        /// <value>The home team quarter three.</value>
		public string HomeTeamQuarterThree => HomeScore.QuarterThreeScore;

        /// <summary>
        /// Gets the home team quarter four.
        /// </summary>
        /// <value>The home team quarter four.</value>
		public string HomeTeamQuarterFour => HomeScore.QuarterFourScore;
       
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public string Result => HomeScore.TotalScore == AwayScore.TotalScore ? StringResource.DrawnLabel : HomeScore.TotalScore > AwayScore.TotalScore ? StringResource.DefeatedLabel : StringResource.DefeatedByLabel;

        /// <summary>
        /// Gets the versing teams.
        /// </summary>
        /// <value>The versing teams.</value>
        public string VersingTeams => $"{HomeTeam}{StringResource.VersusLabel}{AwayTeam}";

        /// <summary>
        /// Gets the short total score.
        /// </summary>
        /// <value>The short total score.</value>
        public string ShortTotalScore => $"{HomeTeamTotalShort}{StringResource.ScoreToLabel}{AwayTeamTotalShort}";
    }
}
