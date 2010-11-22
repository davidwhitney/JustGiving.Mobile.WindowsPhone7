using System;
using System.Windows;
using System.Windows.Controls;
using JustGiving.Api.Sdk.Model.Page;
using JustGiving.App.Code;
using JustGiving.App.ViewModels;
using Microsoft.Phone.Controls;

namespace JustGiving.App
{
    public partial class FundraisingPages : PhoneApplicationPage
    {
        public FundraisingPageSummaries Pages { get; private set; }
        
        private PagesViewModel Context
        {
            get { return ((PagesViewModel)DataContext); }
            set { DataContext = value; }
        }

        public FundraisingPages()
        {
            InitializeComponent();

            ApplicationContext.Client.Page.ListAllAsync(BindPages);
        }

        private void BindPages(FundraisingPageSummaries obj)
        {
            Pages = obj;
            Context = new PagesViewModel(Pages);
            Spinner.Visibility = Visibility.Collapsed;
            pagesTable.Visibility = Visibility.Visible;
        }

        private void Hold(object sender, GestureEventArgs e)
        {
            var pageShortName = ((TextBlock)e.OriginalSource).Name;
            NavigationService.Navigate(new Uri("/FundraisingPage.xaml?pageShortName=" + pageShortName, UriKind.Relative));
        }
    }
}