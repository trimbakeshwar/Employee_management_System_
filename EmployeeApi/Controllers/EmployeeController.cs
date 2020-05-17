using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBusinesLayer.Interfaces;
using EmployeeCommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add_Data(EmployeeModle info)
        {
            string orignal = data.Add_Data(info);
            return Ok(new { orignal });
        }
        [HttpDelete]
        public IActionResult Delete(EmployeeModle id)
        {
            string orignal = data.Delete(id);
            return Ok(new { orignal });
        }
        [HttpPatch]
        public IActionResult Update(EmployeeModle Data)
        {
            string orignal = data.Update(Data);
            return Ok(new { orignal });
        }
        [HttpGet]
        public IActionResult GetAllEmployeeDetail()
        {
            dynamic orignal = data.GetAllEmployeeDetail();
            return Ok(new { orignal });
        }
        [HttpGet]
        [Route("userId")]
        public IActionResult GetEmployeeDetail(EmployeeModle uid)
        {
            dynamic orignal = data.GetEmployeeDetail(uid);
            return Ok(new { orignal });
        }
        [HttpGet]
        [Route("login")]
        public dynamic userLogin(EmployeeModle Data)
        {
            dynamic orignal = data.userLogin(Data);
            return Ok(new { orignal });
        }

    }
}