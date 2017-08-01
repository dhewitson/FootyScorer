using System;
using FootyScorer.Data.Model;
using FootyScorer.ViewModel;

namespace FootyScorer.Data
{
    public static class DataMapper
    {
        /// <summary>
        /// Converts a model to a view model
        /// </summary>
        /// <returns>The view model.</returns>
        /// <param name="model">Model.</param>
        public static MatchViewModel ToViewModel(this Match model)
        {
            if (model == null) return null;

            return new MatchViewModel
            {
                AwayTeam = model.AwayTeam,
                HomeTeam = model.HomeTeam,
                Date = model.Date,
                Round = model.Round.ToString(),
                Venue = model.Venue,
                Id = model.Id
            };
        }

        /// <summary>
        /// Converts a view model to a model.
        /// </summary>
        /// <returns>The model.</returns>
        /// <param name="model">Model.</param>
		public static Match ToModel(this MatchViewModel model)
		{
			if (model == null) return null;

			return new Match
			{
				AwayTeam = model.AwayTeam,
				HomeTeam = model.HomeTeam,
                HomeScore = model.HomeScore.Id,
                AwayScore = model.AwayScore.Id,
				Date = model.Date,
                Round = Convert.ToInt32(model.Round ?? "0"),
				Venue = model.Venue,
				Id = model.Id
			};
		}

		/// <summary>
		/// Converts a score view model to a model
		/// </summary>
		/// <returns>The model.</returns>
		/// <param name="model">Model.</param>
		public static Score ToModel(this ScoreViewModel model)
        {
            if (model == null) return null;

            return new Score
            {
                Id = model.Id,
                QuarterOneGoals = model.QuarterOneGoals,
                QuarterOnePoints = model.QuarterOnePoints,
                QuarterTwoGoals = model.QuarterTwoGoals,
                QuarterTwoPoints = model.QuarterTwoPoints,
                QuarterThreeGoals = model.QuarterThreeGoals,
                QuarterThreePoints = model.QuarterThreePoints,
                QuarterFourGoals = model.QuarterFourGoals,
                QuarterFourPoints = model.QuarterFourPoints
            };
        }

        /// <summary>
        /// Converts a score model to a view model
        /// </summary>
        /// <returns>The view model.</returns>
        /// <param name="model">Model.</param>
		public static ScoreViewModel ToViewModel(this Score model)
		{
			if (model == null) return null;

			return new ScoreViewModel
			{
				Id = model.Id,
				QuarterOneGoals = model.QuarterOneGoals,
				QuarterOnePoints = model.QuarterOnePoints,
				QuarterTwoGoals = model.QuarterTwoGoals,
				QuarterTwoPoints = model.QuarterTwoPoints,
				QuarterThreeGoals = model.QuarterThreeGoals,
				QuarterThreePoints = model.QuarterThreePoints,
				QuarterFourGoals = model.QuarterFourGoals,
				QuarterFourPoints = model.QuarterFourPoints
			};
		}
    }
}
