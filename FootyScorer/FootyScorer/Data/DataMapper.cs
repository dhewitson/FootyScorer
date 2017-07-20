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
				Date = model.Date,
                Round = Convert.ToInt32(model.Round ?? "0"),
				Venue = model.Venue,
				Id = model.Id
			};
		}
    }
}
