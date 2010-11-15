using System.Windows;
using JustGiving.Api.Sdk.Model.Page;
using JustGiving.App.Code;
using Microsoft.Phone.Controls;

namespace JustGiving.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext.SetApiContext(tbUsername.Text, tbPassword.Text);
            ApplicationContext.Client.Page.ListAllAsync(NavigateToLoggedInDisplay);
        }

        private static void NavigateToLoggedInDisplay(FundraisingPageSummaries pages)
        {
            var fundraisingPages = new FundraisingPages(pages);
            Application.Current.RootVisual = fundraisingPages;
        }
    }
}