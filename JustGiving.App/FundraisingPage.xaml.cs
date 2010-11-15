using System.Windows;
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

        public FundraisingPage(Api.Sdk.Model.Page.FundraisingPage page)
        {
            InitializeComponent();

            Page = page;
            Loaded += FundraisingPageLoaded;
        }

        private void FundraisingPageLoaded(object sender, RoutedEventArgs e)
        {
            Context = Page;
        }
    }
}