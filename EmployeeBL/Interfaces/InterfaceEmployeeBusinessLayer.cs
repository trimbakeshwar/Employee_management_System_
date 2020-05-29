using EmployeeCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusinesLayer.Interfaces
{
    public interface InterfaceEmployeeBusinessLayer
    {

        dynamic Registration(EmployeeModle modle);
        dynamic Delete(int id);
        dynamic Update(EmployeeModle data);
        dynamic GetAllEmployeeDetail();
        dynamic GetEmployeeDetail(int uid);
        dynamic userLogin(string userName, string passWord);
        dynamic Add_Data(EmployeeModle data);
    }
}
