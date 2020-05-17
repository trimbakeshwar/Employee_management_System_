using EmployeeCommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusinesLayer.Interfaces
{
    public interface InterfaceEmployeeBusinessLayer
    {
        string Add_Data(EmployeeModle modle);
        string Delete(EmployeeModle id);
        string Update(EmployeeModle data);
        dynamic GetAllEmployeeDetail();
        dynamic GetEmployeeDetail(EmployeeModle uid);
        dynamic userLogin(EmployeeModle data);
    }
}
