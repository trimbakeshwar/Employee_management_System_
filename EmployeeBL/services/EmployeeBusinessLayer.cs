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
        public string Return_Data(EmployeeModle data)
        {
            return this.information.Return_Data(data);
        }
       
    }
}
