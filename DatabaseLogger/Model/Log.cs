using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLogger.Model
{
	[Table("Log")]
	public class Log
	{
		public int ID             { get; set; }
		public string Name        { get; set; }
		public DateTime DateTime  { get; set; }
		public int Level          { get; set; }
		public string Description { get; set; }
		public string Message     { get; set; }
		public string Exception   { get; set; }

		public Log(string name, LogLevel logLevel, string message, Exception exception)
		{
			this.DateTime    = DateTime.Now;
			this.Name        = name;
			this.Level       = (int)logLevel;
			this.Description = logLevel.ToString();
			this.Message     = message;
			this.Exception   = exception?.ToString() ?? "";
		}

		public Log(string name, LogLevel logLevel, string message) : this (name, logLevel, message, null)
		{
		}

		public Log(string name, LogLevel logLevel, Exception exception) : this(name, logLevel, "", exception)
		{
		}
	}
}
