using System;
using System.Windows.Navigation;
using JustGiving.App.Code;
using Microsoft.Phone.Controls;

namespace JustGiving.App
{
    public partial class FundraisingPage : PhoneApplicationPage
    {
        public Api.Sdk.Model.Page.FundraisingPage Page { get; set; }

        private Api.Sdk.Model.Page.FundraisingPage Context
        {
            get { return ((Api.Sdk.Model.Page.FundraisingPage)DataContext); }
            set { DataContext = value; }
        }

        public FundraisingPage()
        {
            InitializeComponent();
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
        }
        
        private void LoadFundraisingPage(Api.Sdk.Model.Page.FundraisingPage obj)
        {
            Page = obj;
            Context = Page;

            Spinner.Visibility = System.Windows.Visibility.Collapsed;
            LayoutRoot.Visibility = System.Windows.Visibility.Visible;
        }
    }
}