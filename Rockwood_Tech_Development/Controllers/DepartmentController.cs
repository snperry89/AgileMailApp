using Rockwood.Models;
using Rockwood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rockwood_Tech_Development.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private DepartmentService CreateDepartmentService()
        {
            var departmentService = new DepartmentService();
            return departmentService;
        }

        public IHttpActionResult Post(DepartmentCreate department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateDepartmentService();
            if (!service.CreateNote(department))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get()
        {
            DepartmentService departmentService = CreateDepartmentService();
            var departments = departmentService.GetDepartments();
            return Ok(departments);
        }
    }
}
