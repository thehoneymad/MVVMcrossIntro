using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace NewsReader.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _title = "NewsReader";
        public string Title
		{ 
			get { return _title; }
			set { _title = value; RaisePropertyChanged(() => Title); }
		}

		private ObservableCollection<string> _newsCollection;
		public ObservableCollection<string> NewsCollection {
			get { return _newsCollection; }
			set { _newsCollection = value; RaisePropertyChanged (()=>NewsCollection);}
		}

		public FirstViewModel ()
		{
			LoadData ();

		}

		public async void LoadData()
		{
			INewsLoadingService service = new NewsLoadingService ();
			NewsCollection=new ObservableCollection<string>(await service.LoadNews ());

		}

		private List<string> ParseResponse(string text)
		{
			var xml = XDocument.Parse(text);
			var items = xml.Descendants("item");

			var list = items.Select(x => x.Element("description").Value.ToString()).ToList();

			return list;

		}
	}
}
