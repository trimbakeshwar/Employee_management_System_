using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeCommonLayer
{
    public class EmployeeModle
    {


        [Required(ErrorMessage = "firstName is required")]
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid first Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "lastName is required")]
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "payment is required")]
        [RegularExpression(@"^[0-9]{3,}.[0-9]{1,}$")]
        public decimal payment { get; set; }
        public int userId { get; set; }
        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"^((.[A-Z]+[a-z]*[0-9]*)|(.[A-Z]*[a-z]+[0-9]*)|(.[A-Z]*[a-z]*[0-9]+)?)?@.co(.[a-z]{2,})?$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "username is required")]
        [RegularExpression(@"^[a-z0-9_-]{3,15}$", ErrorMessage = "Please enter a valid user Name")]
        public string userName { get; set; }
        [Required(ErrorMessage = "password is required")]
        [RegularExpression(@"^.*(?=.*[A-Z])*(?=.*[0-9])*(?=.*[a-z])*(?=.*[!@#$%^&*_+]{1})(.{8,})$", ErrorMessage = "Please enter a valid password")]
        public string passWord { get; set; }
       

    }
}
