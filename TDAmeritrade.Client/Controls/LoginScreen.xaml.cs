// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginScreen.xaml.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Controls
{
    using System.Windows;
    using System.Windows.Input;

    using TDAmeritrade.Client.Utility;

    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private const string UserNameKey = "UserName";
        private const string RememberUserNameKey = "RememberUserName";

        private readonly AmeritradeClient client;

        public LoginScreen()
        {
            this.InitializeComponent();

            this.UserName.Text = Settings.GetProtected(UserNameKey);
            this.RememberUserName.IsChecked = Settings.Get(RememberUserNameKey, defaultValue: true);
            this.ErrorMessage.Visibility = Visibility.Collapsed;

            if (!string.IsNullOrWhiteSpace(this.UserName.Text))
            {
                this.Password.Focus();
            }
        }

        public LoginScreen(AmeritradeClient client)
            : this()
        {
            this.client = client;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.UserName.Text) || string.IsNullOrWhiteSpace(this.Password.Password))
            {
                this.ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            Settings.SetProtected(UserNameKey, this.RememberUserName.IsChecked.Value ? this.UserName.Text : string.Empty);
            Settings.Set(RememberUserNameKey, this.RememberUserName.IsChecked.Value);

            this.UserName.IsEnabled = false;
            this.Password.IsEnabled = false;
            this.LoginButton.IsEnabled = false;

            var result = await this.client.LogIn(this.UserName.Text, this.Password.Password);

            if (!result)
            {
                this.UserName.IsEnabled = true;
                this.Password.IsEnabled = true;
                this.LoginButton.IsEnabled = true;
                this.ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            this.DialogResult = result;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
