using System;
using System.Windows;
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

        public FundraisingPages(FundraisingPageSummaries pages)
        {
            InitializeComponent();
            
            Pages = pages;
            Loaded += FundraisingPagesLoaded;
        }

        private void FundraisingPagesLoaded(object sender, RoutedEventArgs e)
        {
            Context = new PagesViewModel(Pages);
        }

        private void ContextMenuOpened(object sender, RoutedEventArgs e)
        {
            var contextMenuInstance = (ContextMenu)sender;
            var pageShortName = contextMenuInstance.Name;

            ApplicationContext.Client.Page.RetrieveAsync(pageShortName, LoadFundraisingPage);
        }

        private static void LoadFundraisingPage(Api.Sdk.Model.Page.FundraisingPage obj)
        {
            var fundraisingPage = new FundraisingPage(obj);
            Application.Current.RootVisual = fundraisingPage;
        }
    }
}