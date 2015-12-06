using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseLogger.Model;

namespace DatabaseLogger
{

	public class Logger
	{

		#region Constructor & Members

		private string name;

		public Logger(string name)
		{
			this.name = name;
		}

		#endregion Constructor & Members



		
		#region Public Methods

		public void Log(LogLevel logLevel, string message, Exception exception)
		{
			using (LogDB logDB = new LogDB())
			{
				Log log = new Log(this.name, LogLevel.FATAL, message, exception);

				logDB.Logs.Add(log);
				logDB.SaveChanges();
			}
		}


		public void LogFatal(string message, Exception exception)
		{
			Log(LogLevel.FATAL, message, exception);
		}

		public void LogFatal(string message)
		{
			LogFatal(message, null);
		}

		public void LogFatal(Exception exception)
		{
			LogFatal("", exception);
		}


		public void LogError(string message, Exception exception)
		{
			Log(LogLevel.ERROR, message, exception);
		}

		public void LogError(string message)
		{
			LogError(message, null);
		}

		public void LogError(Exception exception)
		{
			LogError("", exception);
		}


		public void LogWarning(string message, Exception exception)
		{
			Log(LogLevel.ERROR, message, exception);
		}

		public void LogWarning(string message)
		{
			LogWarning(message, null);
		}

		public void LogWarning(Exception exception)
		{
			LogWarning("", exception);
		}


		public void LogInfo(string message, Exception exception)
		{
			Log(LogLevel.ERROR, message, exception);
		}

		public void LogInfo(string message)
		{
			LogInfo(message, null);
		}

		public void LogInfo(Exception exception)
		{
			LogInfo("", exception);
		}


		public void LogDebug(string message, Exception exception)
		{
			Log(LogLevel.ERROR, message, exception);
		}

		public void LogDebug(string message)
		{
			LogDebug(message, null);
		}

		public void LogDebug(Exception exception)
		{
			LogDebug("", exception);
		}

		#endregion Public Methods

	}
}
