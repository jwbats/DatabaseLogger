using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogger
{

	[Table("Logs")]
	public class Log
	{
		public int ID             { get; set; }
		public DateTime DateTime  { get; set; }
		public int Level          { get; set; }
		public string Description { get; set; }
		public string Message     { get; set; }
		public string Exception   { get; set; }
	}


	public class EntitiesContext : DbContext
	{
		public EntitiesContext() : base("EntitiesConnection")
		{
		}

		public DbSet<Log> Logs { get; set; }
	}


	public class DbLogger
	{

		public DbLogger()
		{
		}


		public void Log(int level, string description, string message, string exception)
		{
			Log log = new DatabaseLogger.Log()
			{
				DateTime    = DateTime.Now,
				Level       = level,
				Description = description,
				Message     = message,
				Exception   = exception
			};

			using (EntitiesContext context = new EntitiesContext())
			{
				context.Logs.Add(log);
				context.SaveChanges();
			}


		}

	}
}
