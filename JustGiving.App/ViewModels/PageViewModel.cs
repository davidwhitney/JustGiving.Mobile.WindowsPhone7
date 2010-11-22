using System;
using System.ComponentModel;
using JustGiving.Api.Sdk.Model.Page;

namespace JustGiving.App.ViewModels
{
    public class PageViewModel : INotifyPropertyChanged
    {
        private Api.Sdk.Model.Page.FundraisingPage _page;
        public Api.Sdk.Model.Page.FundraisingPage Page
        {
            get { return _page; }
            set { _page = value; NotifyPropertyChanged("Page"); }
        }

        private FundraisingPageDonations _donations;
        public FundraisingPageDonations Donations
        {
            get { return _donations; }
            set { _donations = value; NotifyPropertyChanged("Donations"); }
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