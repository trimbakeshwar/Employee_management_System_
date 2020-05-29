using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeCommonLayer
{
    public class EmployeeModle
    {


       
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid first Name")]
        public string firstName { get; set; }
       
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid last Name")]
        public string lastName { get; set; }
       
        public string Qualification { get; set; }
        
        [RegularExpression(@"^[0-9]{3,}.[0-9]{1,}$", ErrorMessage = "Please enter proper payment")]
        public decimal payment { get; set; }

        public int userId { get; set; }
       
        [RegularExpression(@"^((.[A-Z]+[a-z]*[0-9]*)|(.[A-Z]*[a-z]+[0-9]*)|(.[A-Z]*[a-z]*[0-9]+)?)?@.co(.[a-z]{2,})?$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
       
        [RegularExpression(@"^[a-z0-9_-]{3,15}$", ErrorMessage = "Please enter a valid user Name")]
        public string userName { get; set; }
       
        [RegularExpression(@"^.*(?=.*[A-Z])*(?=.*[0-9])*(?=.*[a-z])*(?=.*[!@#$%^&*_+]{1})(.{8,})$", ErrorMessage = "Please enter a valid password")]
        public string passWord { get; set; }
       

    }
}
