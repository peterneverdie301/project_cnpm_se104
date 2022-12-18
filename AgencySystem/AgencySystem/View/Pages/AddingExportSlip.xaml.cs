using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgencySystem.View.Pages;

public partial class AddingExportSlip : Page
{
    public AddingExportSlip()
    {
        InitializeComponent();
        List<User> items = new List<User>();
        items.Add(new User() { Product = "ca com", Quantity = 20,  Unit= "kg" });
        lvUsers.ItemsSource = items;                
    }

    public class User
    {
        public string Product { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }
    }
}