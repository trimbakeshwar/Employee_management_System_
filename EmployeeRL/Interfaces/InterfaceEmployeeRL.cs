using EmployeeCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRL.Interfaces
{
    public interface InterfaceEmployeeRL
    {
        dynamic Registration(EmployeeModle modle);
        dynamic Delete(int id);
        dynamic Update(EmployeeModle Data);
        dynamic GetAllEmployeeDetail();
        dynamic GetEmployeeDetail(int uid);
        dynamic userLogin(string userName, string passWord);
        dynamic Add_Data(EmployeeModle data);
    }
}
