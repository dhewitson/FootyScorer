﻿using System;
using System.Collections.Generic;
using System.Linq;
using FootyScorer.Data.Model;
using FootyScorer.ViewModel;
using SQLite.Net;

namespace FootyScorer.Data
{
    public class DataManager
    {
        private readonly DatabaseManager _dbManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FootyScorer.Data.DataManager"/> class.
        /// </summary>
        /// <param name="connection">Connection.</param>
        public DataManager(SQLiteConnection connection)
        {
            _dbManager = new DatabaseManager(connection);
        }

        /// <summary>
        /// Saves a match.
        /// </summary>
        /// <param name="match">Match.</param>
        public void SaveMatch(MatchViewModel match)
        {
            _dbManager.SaveScore(match.AwayScore.ToModel());
            _dbManager.SaveScore(match.HomeScore.ToModel());
            _dbManager.SaveMatch(match.ToModel());
        }

        /// <summary>
        /// Gets a match.
        /// </summary>
        /// <returns>The match.</returns>
        /// <param name="func">Func.</param>
        public MatchViewModel GetMatch(Func<Match, bool> func)
        {
            var dbMatch = _dbManager.GetMatches(func).FirstOrDefault();

            if (dbMatch == null) return null;

            var match = dbMatch.ToViewModel();

            match.AwayScore = _dbManager.GetScore(dbMatch.AwayScore).ToViewModel();
            match.HomeScore = _dbManager.GetScore(dbMatch.HomeScore).ToViewModel();

            return match;
        }

        /// <summary>
        /// Creates the new match.
        /// </summary>
        /// <returns>The new match.</returns>
        public MatchViewModel CreateNewMatch()
        {
            var match = new MatchViewModel
            {
                Id = Guid.NewGuid(),
                AwayScore = new ScoreViewModel
                {
                    Id = Guid.NewGuid()
                },
                HomeScore = new ScoreViewModel
                {
                    Id = Guid.NewGuid()
                },
                HomeTeam = "Home Team",
                AwayTeam = "Away Team",
                Round = "0",
                Venue = "Enter Venue",
                Date = DateTime.Now
            };

            return match;
        }

        /// <summary>
        /// Gets the matches.
        /// </summary>
        /// <returns>The matches.</returns>
        /// <param name="func">Func.</param>
        public List<MatchViewModel> GetMatches(Func<Match, bool> func)
        {
            var dbMatches = _dbManager.GetMatches(func)?.ToList();

            if (dbMatches == null) return new List<MatchViewModel>();

            var matches = new List<MatchViewModel>();

            foreach (var m in dbMatches)
            {
                var match = m.ToViewModel();
				match.AwayScore = _dbManager.GetScore(m.AwayScore).ToViewModel();
				match.HomeScore = _dbManager.GetScore(m.HomeScore).ToViewModel();

                matches.Add(match);
            }

            return matches;
        }


    }
}
