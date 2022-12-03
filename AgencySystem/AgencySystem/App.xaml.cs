using AgencySystem.Controller;
using AgencySystem.View;
using AgencySystem.View.MainWindow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AgencySystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow main = new MainWindow();
            MainWindowController mainWindowController = new MainWindowController();
            main.DataContext = mainWindowController;
            main.Show();
        }
    }
}
