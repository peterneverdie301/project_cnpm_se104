using DataModels.Models;
using DataModels.Services;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class AddingAgency : Page
{
    private Firestore firestore = new Firestore();
    public AddingAgency()
    {
        InitializeComponent();
    }

    private async void handleAddAgency(object sender, MouseButtonEventArgs e)
    {
        #region Get Data
        //object data = await firestore.GetData(Utils.Collection.Agency.ToString(), "dl-01");
        //Agency agency = (Agency)data;
        //TbName.Text = agency.AgencyName;
        //MessageBox.Show("Lấy data thành công");
        #endregion
        #region Add Data
        //Agency agency = new Agency();
        //agency.AgencyId = "dl-02";
        //agency.AgencyName = "Linh";
        //agency.DayReception = Timestamp.GetCurrentTimestamp();
        //firestore.AddData(Utils.Collection.Agency.ToString(), agency.AgencyId, agency);
        //MessageBox.Show("Thêm data thành công");
        #endregion
        #region Update Data
        //Agency agency = new Agency();
        //agency.AgencyId = "dl-01";
        //agency.AgencyName = "Văn Linh";
        //agency.DayReception = Timestamp.GetCurrentTimestamp();
        //firestore.AddData(Utils.Collection.Agency.ToString(), agency.AgencyId, agency);
        //MessageBox.Show("Cập nhật thành công");
        #endregion
        #region Delete Data
        //firestore.DeleteData(Utils.Collection.Agency.ToString(), "dl-03");
        //MessageBox.Show("Xóa thành công");
        #endregion
        #region Get All Collection (Table)
        //List<object> listData = await firestore.GetAllDocument(Utils.Collection.Agency.ToString());
        //foreach (Agency item in listData)
        //{
        //    MessageBox.Show(item.AgencyName);
        //}
        #endregion
    }
}