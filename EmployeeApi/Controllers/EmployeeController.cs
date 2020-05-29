using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBusinesLayer.Interfaces;
using EmployeeCommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private InterfaceEmployeeBusinessLayer data;

        public EmployeeController(InterfaceEmployeeBusinessLayer data)
        {
            this.data = data;
        }
        [HttpPost]
        public IActionResult Registration(EmployeeModle info)
        {
            dynamic orignal = data.Registration(info);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            return Ok(new { status, massage });
            
        }
        [HttpPut]
        public IActionResult Add_Data(EmployeeModle info)
        {
            dynamic orignal = data.Add_Data(info);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            return Ok(new { status, massage });
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            dynamic orignal = data.Delete(id);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            return Ok(new { status, massage });
        }
        [HttpPatch]
        public IActionResult Update(EmployeeModle Data)
        {
            dynamic orignal = data.Update(Data);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            return Ok(new { status, massage });
        }
        [HttpGet]
        public IActionResult GetAllEmployeeDetail()
        {
            dynamic orignal = data.GetAllEmployeeDetail();
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            dynamic result = orignal.Item3;
            return Ok(new { status, massage, result });
        }
        [HttpGet("{userId}")]
       
        public IActionResult GetEmployeeDetail(int userId)
        {
            dynamic orignal = data.GetEmployeeDetail(userId);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            dynamic result = orignal.Item3;
            return Ok(new { status, massage, result });
        }
        [HttpGet]
        [Route("login/{userName}/{passWord}")]
        public IActionResult userLogin(string userName,string passWord)
        {
            dynamic orignal = data.userLogin(userName, passWord);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
           
            return Ok(new { status, massage });
        }

    }
}