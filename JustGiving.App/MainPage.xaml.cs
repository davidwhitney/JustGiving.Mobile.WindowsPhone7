using System;
using System.Windows;
using JustGiving.Api.Sdk.Model.Page;
using JustGiving.App.Code;
using Microsoft.Phone.Controls;

namespace JustGiving.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext.SetApiContext(tbUsername.Text, tbPassword.Text);
            NavigationService.Navigate(new Uri("/FundraisingPages.xaml", UriKind.Relative));
        }
    }
}