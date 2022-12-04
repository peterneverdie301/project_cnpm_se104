using DataModels.Models;
using DataModels.Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgencySystem.View.Pages;

public partial class AddingAgency : Page
{
    public AddingAgency()
    {
        InitializeComponent();
    }

    private void handleAddAgency(object sender, MouseButtonEventArgs e)
    {
        #region GetList
        //IEnumerable<Agency> listAgency = AgencyRepository.GetAgencyList();
        //string name = "";
        //foreach (var item in listAgency)
        //{
        //    name += item.AgencyName + " ";
        //}
        //MessageBox.Show(name);
        #endregion
        #region GetById
        //Agency angency = AgencyRepository.GetAgencyById("1");
        //MessageBox.Show(angency.AgencyName);
        #endregion
        #region Addnew
        //Agency agencyNew = new Agency();
        //agencyNew.AgencyName = "Linh Nguyễn";
        //agencyNew.AgencyId = "2";
        //AgencyRepository.AddNew(agencyNew);
        //MessageBox.Show("Done");
        #endregion
        /*
         * Update and remove là dùng theo Id 
         * C1: Nên có thể get về để xóa/thay đổi
         * C2: Hoặc có thể tạo object mới có Id = Id của object muốn thay đổi
         * Lưu ý: khi update nếu dùng C2 khi muốn thay hoàn toàn mới. Nếu muốn thay đổi 1 thành phần thì nên dùng C1
        */
        #region Update
        //Agency agencyUpdate = AgencyRepository.GetAgencyById("1");
        //agencyUpdate.AgencyName = "Ngài Gấu";
        //AgencyRepository.Update(agencyUpdate);
        //MessageBox.Show("Done");
        #endregion
        #region Remove
        //Agency agencyRemove = AgencyRepository.GetAgencyById("2");
        //AgencyRepository.Remove(agencyRemove);
        //MessageBox.Show("Done");
        #endregion

    }
}