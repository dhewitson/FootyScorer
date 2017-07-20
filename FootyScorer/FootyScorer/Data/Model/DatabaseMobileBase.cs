using System;
using SQLite.Net.Attributes;

namespace FootyScorer.Data.Model
{
    public class DatabaseMobileBase
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
    }
}
