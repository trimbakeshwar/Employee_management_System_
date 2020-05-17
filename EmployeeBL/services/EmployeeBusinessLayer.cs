using EmployeeBusinesLayer.Interfaces;
using EmployeeCommonLayer;
using EmployeeRL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusinesLayer.services
{
    public class EmployeeBusinessLayer : InterfaceEmployeeBusinessLayer
    {
        private InterfaceEmployeeRL information;
        public EmployeeBusinessLayer(InterfaceEmployeeRL information)
        {
            this.information = information;
        }
        public string Add_Data(EmployeeModle data)
        {
            return this.information.Add_Data(data);
        }
        public string Delete(EmployeeModle id)
        {
            return this.information.Delete(id);
        }
        public string Update(EmployeeModle Data)
        {            
            return this.information.Update(Data);            
        }
        public dynamic GetAllEmployeeDetail()
        {
            return this.information.GetAllEmployeeDetail();
        }
        public dynamic GetEmployeeDetail(EmployeeModle uid)
        {
            return this.information.GetEmployeeDetail(uid);
        }
        public dynamic userLogin(EmployeeModle data)
        {
            return this.information.userLogin(data);
        }




    }
}
