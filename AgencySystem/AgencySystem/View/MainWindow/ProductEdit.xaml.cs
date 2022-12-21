using DataModels.Models;
using DataModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AgencySystem.View.MainWindow;

    public partial class ProductEdit : Window
    {
        Firestore firestore = new Firestore();
        List<object> units;
        public ProductEdit()
        {
            InitializeComponent();
            setUp();
        }
        private async void setUp()
        {
            units = new List<object>();
            units = await firestore.GetAllDocument(Utils.Collection.Units.ToString());
            foreach (Unit unit in units)
            {
                if (unit.Value != null)
                {
                    cbxUnit.Items.Add(unit.Value);
                }
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item()
            {
                ItemsId = TbProduct.Tag.ToString(),
                ItemsName = TbProduct.Text,
                UnitId = cbxUnit.Text,
                Price = Convert.ToDouble(TbPrice.Text),
            };
            firestore.UpdateData(Utils.Collection.Items.ToString(), item.ItemsId, item);
            MessageBox.Show("Cập nhật thành công!");
            this.Tag = item;
            this.Close();
        }

        private void TbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

