using System;
using System.Collections.Generic;
using System.Linq;
using FootyScorer.Data.Model;
using SQLite.Net;

namespace FootyScorer.Data
{
    public class DatabaseManager
    {
		private static readonly object Locker = new object();
		private readonly SQLiteConnection _database;

        public DatabaseManager(SQLiteConnection connection)
        {
			_database = connection;
			_database.CreateTable<Match>();
			_database.CreateTable<Score>();
        }

        /// <summary>
        /// Gets all matches in the database
        /// </summary>
        /// <returns>The matches.</returns>
		public List<Match> GetMatches(Func<Match, bool> func)
		{
			lock (Locker)
				return _database.Table<Match>().Where(func).ToList();
		}

        /// <summary>
        /// Gets a score.
        /// </summary>
        /// <returns>The score.</returns>
        /// <param name="scoreId">Score identifier.</param>
        public Score GetScore(Guid scoreId)
        {
            lock (Locker) 
                return _database.Table<Score>().Where(s => s.Id == scoreId).FirstOrDefault();
        }

        /// <summary>
        /// Saves the match.
        /// </summary>
        /// <param name="match">Match.</param>
        public void SaveMatch(Match match)
        {
            ExecuteInsertOrReplace(match);
        }

        /// <summary>
        /// Saves the score.
        /// </summary>
        /// <param name="score">Score.</param>
        public void SaveScore(Score score)
        {
            ExecuteInsertOrReplace(score);
        }

        private void ExecuteInsertOrReplace(object insertObject)
        {
			lock (Locker)
			{
				try
				{
					_database.RunInTransaction(() =>
					{
						_database.InsertOrReplace(insertObject);
					});
				}
				catch (Exception)
				{
				}
			}
        }
    }
}
