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
        public dynamic Registration(EmployeeModle data)
        {
            return this.information.Registration(data);
        }
        public dynamic Delete(int id)
        {
            return this.information.Delete(id);
        }
        public dynamic Update(EmployeeModle Data)
        {            
            return this.information.Update(Data);            
        }
        public dynamic GetAllEmployeeDetail()
        {
            return this.information.GetAllEmployeeDetail();
        }
        public dynamic GetEmployeeDetail(int uid)
        {
            return this.information.GetEmployeeDetail(uid);
        }
        public dynamic userLogin(string userName, string passWord)
        {
            return this.information.userLogin(userName, passWord);
        }
        public dynamic Add_Data(EmployeeModle data)
        {
            return this.information.Add_Data(data);
        }


    }
}
