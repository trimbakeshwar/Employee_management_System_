using EmployeeCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRL.Interfaces
{
    public interface InterfaceEmployeeRL
    {
        string Add_Data(EmployeeModle modle);
        string Delete(EmployeeModle id);
        string Update(EmployeeModle Data);
        dynamic GetAllEmployeeDetail();
        dynamic GetEmployeeDetail(EmployeeModle uid);
        dynamic userLogin(EmployeeModle data);
    }
}
