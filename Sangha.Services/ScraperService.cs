using Sangha.Models.TalkModels;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Services
{
    public class ScraperService
    {
        private ObservableCollection<TalkListItem> _talkEntries = new ObservableCollection<TalkListItem>();
        
        public ObservableCollection<TalkListItem> TalkEntries
        {
            get { return _talkEntries; }
            set { _talkEntries = value; }
        }

        public void ScrapeData(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var articles = doc.DocumentNode.SelectNodes("//*[@class='talklist']/table/tbody/tr");
        }
    }
}
