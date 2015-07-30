using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChechingArchive
{
	public class Program
	{
		private static readonly string _login = ConfigurationManager.AppSettings["login"];
		private static readonly string _password = ConfigurationManager.AppSettings["password"];
		private static readonly string _ftpServer = ConfigurationManager.AppSettings["ftpServer"];
		private static readonly string _path = ConfigurationManager.AppSettings["path"];
		private static readonly string _fileName = ConfigurationManager.AppSettings["fileName"];
		private static readonly string _saveToPath = ConfigurationManager.AppSettings["saveToPath"];

		static void Main(string[] args)
		{
			var conFtp = new ConnectionToFtp(_login, _password, _ftpServer, _path, _fileName);
			var response = conFtp.GetResponse();
			if (response != null)
			{
				Console.WriteLine(response.StatusCode);
				Console.WriteLine(response.StatusDescription);
				Console.WriteLine(response.WelcomeMessage);
				Console.ReadLine();
				response.Dispose();
			}

			conFtp.Download(_saveToPath, _fileName);
		}
	}
}
