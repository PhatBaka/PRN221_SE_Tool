﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Helpers.Logger
{
	public static class LoggerService
	{
		public static void VerifyDir(string path)
		{
			try
			{
				DirectoryInfo dir = new DirectoryInfo(path);
				if (!dir.Exists)
				{
					dir.Create();
				}
			}
			catch { }
		}

		public static void Logger(string lines)
		{
			string path = "C:/Log/";
			VerifyDir(path);
			string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_Errors_Logs.txt";
			try
			{
				StreamWriter file = new StreamWriter(path + fileName, true);
				file.WriteLine(DateTime.Now.ToString() + ": " + lines);
				file.Close();
			}
			catch (Exception) { }
		}
	}
}
