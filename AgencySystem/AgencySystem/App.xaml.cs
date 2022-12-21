using AgencySystem.View;
using AgencySystem.View.MainWindow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AgencySystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow main;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            startMainWindow();
        }

        void startMainWindow()
        {
            main = new MainWindow();
            main.Hide();
            startLoginWindow();
        }

        void startLoginWindow()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Closed += LoginWindow_Closed;
            loginWindow.Show();
        }

        private void LoginWindow_Closed(object? sender, EventArgs e)
        {
            main.Show();
        }
    }
}
