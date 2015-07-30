using System;
using System.IO;
using System.Net;

namespace ChechingArchive
{
	public class ConnectionToFtp
	{
		String Uri { get; set; }

		public ConnectionToFtp(string login, string password, string ftpServer, string path, string fileName)
		{
			Uri = String.Format("ftp://{0}:{1}@{2}/{3}/{4}", login, password, ftpServer, path, fileName);
		}

		public FtpWebResponse GetResponse()
		{
			FtpWebResponse response = null;
			try
			{
				var request = (FtpWebRequest)WebRequest.Create(Uri);
				response = (FtpWebResponse)request.GetResponse();
				return response;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.ReadLine();
			}
			return response;
		}

		public void Download(string saveToPath, string fileName)
		{
			using (var client = new WebClient())
			{
				client.DownloadFile(Uri, saveToPath + fileName);
			}
		}
	}
}
