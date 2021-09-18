using APTraining.Services;
//using APTraining.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APTraining.Models;
using Microsoft.AspNet.OData;
namespace APTraining.Controllers
{
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        [Route("api/odata/employees/certificates/all/{id}")]
        public async Task<IActionResult> GetAllCertificates(int id)
        {
            var result = await _certificateService.GetEmployeesCertificatesAll(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/employees/certificates/last/{id}")]
        public async Task<IActionResult> GetlastCertificates(int id)
        {
            var result = await _certificateService.GetEmployeesCertificatesLast(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/crew/expiring/certificates/{id}")]
        public async Task<IActionResult> CrewExpiringCertificates(int id)
        {
            var result = await _certificateService.GetCrewExpiringCertificates(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/employees/expiringcertificates/last/{id}")]
        public async Task<IActionResult> GetLastExpiringCertificates(int id)
        {
            var result = await _certificateService.GetEmployeesCertificatesLast(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/crew/expires/{id}")]
        public async Task<IActionResult> GetCrewExpires(int id)
        {
            var result = await _certificateService.GetCrewExpires(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/employee/certificates/{id}")]
        public async Task<IActionResult> GetEmployeeCertificates(int id)
        {
            var result = await _certificateService.GetEmployeeCertificates(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/employee/certificates/type/{id}/{tid}")]
        public async Task<IActionResult> GetEmployeeCertificatesByType(int id, int tid)
        {
            var result = await _certificateService.GetEmployeeCertificatesBytype(id, tid);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/odata/employee/certificates/{id}/{tid}")]
        public async Task<IActionResult> GetEmployeeCertificatesByType2(int id, int tid)
        {
            var result = await _certificateService.GetEmployeeCertificatesBytype2(id, tid);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/odata/certificate/save")]
        public async Task<IActionResult> SaveCertificates(Certification dto)
        {
            var result = await _certificateService.SaveCertificates(dto);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/odata/certificate/delete/{id}")]
        public async Task<IActionResult> DeleteCertificates(int id)
        {
            var result = await _certificateService.DeleteCertificates(id);
            return Ok(result);
        }


    }
}
