using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APCore.Models;
using APCore.Services;
using APCore.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {

            _libraryService = libraryService;
        }

        [HttpGet]
        [Authorize]
        [Route("api/employees/library/{id}/{cid}/{type?}")]
        public async Task<IActionResult> GetViewBookApplicableEmployee(int id, int cid, int? type = null)
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _libraryService.GetViewBookApplicableEmployee(id, cid, type);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        //Task<DataResponse> GetLibraryEmployeeFolderCustomer(int pid, int fid, int eid, int cid);
        [HttpGet]
        //[Authorize]
        [Route("api/base/library/employee/folder/{eid}/{fid}/{pid}/{cid}")]
        public async Task<IActionResult> GetLibraryEmployeeFolderCustomer(int pid, int fid, int eid, int cid)
        {
            //  var userData = User.FindFirst(ClaimTypes.UserData).Value;

            var result = await _libraryService.GetLibraryEmployeeFolderCustomer(pid,fid,eid,cid);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("api/file/visit")]
        public async Task<IActionResult> SaveFileVisit(dynamic dto)
        {
            var employeeId = Convert.ToInt32(dto.employeeId);
            var fileId = Convert.ToInt32(dto.fileId);
            var result = await _libraryService.VisitBookFile(employeeId, fileId);
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }


    }
}
