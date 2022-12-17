﻿using AgencySystem.View.Components;
using AgencySystem.View.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.MainWindow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        if (LbView != null) LbView.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new OverView();
    }

    private void handleClose(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }

    // private void handleChangePage(object sender, MouseButtonEventArgs e)
    // {
    //     Label data = (Label)sender;
    //     switch (data.Content)
    //     {
    //         case "View":
    //             FrContainer.Content = new OverView();
    //             break;
    //         case "Adding Agency":
    //             FrContainer.Content = new AddingAgency();
    //             break;
    //         case "Adding Receipts":
    //             FrContainer.Content = new AddingReceipt();
    //             break;
    //         case "Report":
    //             FrContainer.Content = new Report();
    //             break;
    //         default:
    //             break;
    //     }
    // }

    private void LbView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbView.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new OverView();
    }

    private void LbAdding_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbAdding.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new Adding();
    }

    private void LbReport_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ResetNavItemsToDefault();
        LbReport.Style = Resources["NavItemClickedStyle"] as Style;
        FrContainer.Content = new Report();
    }

    private void ResetNavItemsToDefault()
    {
        LbView.Style = Resources["NavItemStyle"] as Style;
        LbAdding.Style = Resources["NavItemStyle"] as Style;
        LbReport.Style = Resources["NavItemStyle"] as Style;
    }
}