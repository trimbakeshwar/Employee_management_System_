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
        public IActionResult Return_Data(EmployeeModle info)
        {
            string orignal = data.Return_Data(info);
            return Ok(new { orignal });
        }
    }
}