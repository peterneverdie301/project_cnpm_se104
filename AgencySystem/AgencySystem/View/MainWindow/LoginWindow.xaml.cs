﻿using System;
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

namespace AgencySystem.View.MainWindow;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(PbPassword.Password.ToString() == TbUserName.Text && PbPassword.Password.ToString() != "" && TbUserName.Text != "") {
            this.Close();
        }
        else
        {
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        }
    }
}