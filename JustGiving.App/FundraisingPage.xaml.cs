using System;
using System.Windows.Navigation;
using JustGiving.Api.Sdk.Model.Page;
using JustGiving.App.Code;
using JustGiving.App.ViewModels;
using Microsoft.Phone.Controls;

namespace JustGiving.App
{
    public partial class FundraisingPage : PhoneApplicationPage
    {
        public Api.Sdk.Model.Page.FundraisingPage Page { get; set; }

        private PageViewModel Context
        {
            get { return ((PageViewModel)DataContext); }
            set { DataContext = value; }
        }

        public FundraisingPage()
        {
            InitializeComponent();
            Context = new PageViewModel();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string pageShortName;
            if (!NavigationContext.QueryString.TryGetValue("pageShortName", out pageShortName))
            {
                throw new Exception("Need a pageShortName");
            }
            
            ApplicationContext.Client.Page.RetrieveAsync(pageShortName, LoadFundraisingPage);
            ApplicationContext.Client.Page.RetrieveDonationsForPageAsync(pageShortName, DonationsLoaded);
        }

        private void LoadFundraisingPage(Api.Sdk.Model.Page.FundraisingPage obj)
        {
            Page = obj;
            Context.Page = Page;

            Spinner.Visibility = System.Windows.Visibility.Collapsed;
            LayoutRoot.Visibility = System.Windows.Visibility.Visible;
        }

        private void DonationsLoaded(FundraisingPageDonations obj)
        {
            Context.Donations = obj;
            donationsList.DataContext = Context.Donations;
        }
    }
}