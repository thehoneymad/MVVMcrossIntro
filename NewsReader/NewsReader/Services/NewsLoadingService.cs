using System;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace NewsReader
{
	public class NewsLoadingService:INewsLoadingService
	{
		public NewsLoadingService ()
		{
		}

		#region INewsLoadingService implementation

		public async System.Threading.Tasks.Task<System.Collections.Generic.List<string>> LoadNews ()
		{
			HttpClient client = new HttpClient ();
			var data = await client.GetStringAsync ("http://www.bbc.co.uk/sport/football/premier-league/rss.xml");
			var News = ParseResponse (data);
			return News;
		}

		#endregion

		private List<string> ParseResponse(string text)
		{
			var xml = XDocument.Parse(text);
			var items = xml.Descendants("item");

			var list = items.Select(x => x.Element("description").Value.ToString()).ToList();

			return list;

		}
	}
}

