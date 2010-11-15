using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JustGiving.Api.Sdk.Model.Page;

namespace JustGiving.App.ViewModels
{
    public class PagesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FundraisingPageSummary> PageSummaries { get; set; }

        public PagesViewModel(IEnumerable<FundraisingPageSummary> pageSummaries)
        {
            PageSummaries = new ObservableCollection<FundraisingPageSummary>();
            foreach(var summary in pageSummaries)
            {
                PageSummaries.Add(summary);
            }
            NotifyPropertyChanged("PageSummaries");
        }

        public void Add(FundraisingPageSummary summary)
        {
            PageSummaries.Add(summary);
            NotifyPropertyChanged("PageSummaries");
        }

        public void Clear()
        {
            PageSummaries.Clear();
            NotifyPropertyChanged("PageSummaries");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
