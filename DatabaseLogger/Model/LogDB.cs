using System;
using System.Data.Entity;
using MySql.Data.Entity;

namespace DatabaseLogger.Model
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class LogDB : DbContext
	{
		public LogDB() : base("LogDB")
		{
		}

		public DbSet<Log> Logs { get; set; }
	}
}
