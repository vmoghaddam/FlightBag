using APTraining.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APTraining.Objects;

namespace APTraining.Services
{
    public interface ICertificateService
    {
        Task<DataResponse> GetEmployeesCertificatesAll(int id);
        Task<DataResponse> GetEmployeesCertificatesLast(int id);
        Task<DataResponse> GetCrewExpiringCertificates(int id);
        Task<DataResponse> GetCrewExpires(int id);
        Task<DataResponse> GetLastExpiringCertificates(int id);
        Task<DataResponse> GetEmployeeCertificates(int id);
        Task<DataResponse> GetEmployeeCertificatesBytype(int id, int tid);
        Task<DataResponse> GetEmployeeCertificatesBytype2(int id, int tid);
        Task<DataResponse> SaveCertificates(Certification dto);
        Task<DataResponse> DeleteCertificates(int id);
    }

    public class CertificateService : ICertificateService
    {
        private readonly ppa_cspnContext _context;

        public CertificateService(ppa_cspnContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public async Task<DataResponse> GetEmployeesCertificatesAll(int id)
        {
            var entity = _context.ViewCertificates.Where(q => q.PersonId == id).OrderByDescending(q => q.IsLast).ThenBy(q => q.ExpireStatus).ThenBy(q => q.Remain).ThenByDescending(q => q.DateIssue);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }

        public async Task<DataResponse> GetEmployeesCertificatesLast(int id)
        {

            var entity = _context.ViewCertificates.Where(q => q.PersonId == id && q.IsLast == 1).OrderBy(q => q.ExpireStatus).ThenBy(q => q.Remain);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }

        public async Task<DataResponse> GetCrewExpiringCertificates(int id)
        {

            var entity = _context.ViewCrews.FirstOrDefaultAsync(q => q.PersonId == id);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }
        class crewexpire
        {
            public string Title { get; set; }
            public bool IsExpired { get; set; }
            public bool IsExpiring { get; set; }
            public int? Remaining { get; set; }
        }
        public async Task<DataResponse> GetCrewExpires(int id)
        {


            var result = new List<crewexpire>();
            var crew = await _context.ViewCrews.FirstOrDefaultAsync(q => q.PersonId == id);
            if (crew == null)
                return new DataResponse()
                {
                    Data = result,
                    IsSuccess = false
                };

            if (crew.RemainMedical <= 30)
                result.Add(new crewexpire()
                {
                    Title = "Medical",
                    Remaining = crew.RemainMedical,
                    IsExpired = crew.RemainMedical <= 0,
                    IsExpiring = crew.RemainMedical <= 30,


                });
            //Crew Member Certificate
            if (crew.RemainCMC <= 30)
                result.Add(new crewexpire()
                {
                    Title = "Crew Member Certificate",
                    Remaining = crew.RemainCMC,
                    IsExpired = crew.RemainCMC <= 0,
                    IsExpiring = crew.RemainCMC <= 30,


                });
            if (crew.RemainCCRM <= 30)
                result.Add(new crewexpire()
                {
                    Title = "CCRM",
                    Remaining = crew.RemainCCRM,
                    IsExpired = crew.RemainCCRM <= 0,
                    IsExpiring = crew.RemainCCRM <= 30,


                });
            //Aviation Security
            if (crew.RemainAvSec <= 30)
                result.Add(new crewexpire()
                {
                    Title = "Aviation Security",
                    Remaining = crew.RemainAvSec,
                    IsExpired = crew.RemainAvSec <= 0,
                    IsExpiring = crew.RemainAvSec <= 30,


                });
            //SEPT Theoretical 
            if (crew.RemainSEPT <= 30)
                result.Add(new crewexpire()
                {
                    Title = "SEPT Theoretical",
                    Remaining = crew.RemainSEPT,
                    IsExpired = crew.RemainSEPT <= 0,
                    IsExpiring = crew.RemainSEPT <= 30,


                });
            if (crew.RemainSEPTP <= 30)
                result.Add(new crewexpire()
                {
                    Title = "SEPT Practical",
                    Remaining = crew.RemainSEPTP,
                    IsExpired = crew.RemainSEPTP <= 0,
                    IsExpiring = crew.RemainSEPTP <= 30,


                });

            //Dangerous Goods
            if (crew.RemainDG <= 30)
                result.Add(new crewexpire()
                {
                    Title = "Dangerous Goods",
                    Remaining = crew.RemainDG,
                    IsExpired = crew.RemainDG <= 0,
                    IsExpiring = crew.RemainDG <= 30,


                });
            if (crew.RemainSMS <= 30)
                result.Add(new crewexpire()
                {
                    Title = "SMS",
                    Remaining = crew.RemainSMS,
                    IsExpired = crew.RemainSMS <= 0,
                    IsExpiring = crew.RemainSMS <= 30,


                });
            if (crew.IsCabin == 1)
            {
                if (crew.RemainFirstAid <= 30)
                    result.Add(new crewexpire()
                    {
                        Title = "First Aid",
                        Remaining = crew.RemainFirstAid,
                        IsExpired = crew.RemainFirstAid <= 0,
                        IsExpiring = crew.RemainFirstAid <= 30,


                    });
            }
            if (crew.IsCockpit == 1)
            {
                if (crew.RemainLPR <= 30)
                    result.Add(new crewexpire()
                    {
                        Title = "LPR",
                        Remaining = crew.RemainLPR,
                        IsExpired = crew.RemainLPR <= 0,
                        IsExpiring = crew.RemainLPR <= 30,


                    });
                //Skill Test/Proficiency
                if (crew.RemainProficiency <= 30)
                    result.Add(new crewexpire()
                    {
                        Title = "Skill Test/Proficiency",
                        Remaining = crew.RemainProficiency,
                        IsExpired = crew.RemainProficiency <= 0,
                        IsExpiring = crew.RemainProficiency <= 30,


                    });
                if (crew.RemainColdWeather <= 30)
                    result.Add(new crewexpire()
                    {
                        Title = "Cold Weather",
                        Remaining = crew.RemainColdWeather,
                        IsExpired = crew.RemainColdWeather <= 0,
                        IsExpiring = crew.RemainColdWeather <= 30,


                    });
                if (crew.RemainHotWeather <= 30)
                    result.Add(new crewexpire()
                    {
                        Title = "Hot Weather",
                        Remaining = crew.RemainHotWeather,
                        IsExpired = crew.RemainHotWeather <= 0,
                        IsExpiring = crew.RemainHotWeather <= 30,


                    });
            }
            return new DataResponse()
            {
                IsSuccess = true,
                Data = result
            };
        }

        public async Task<DataResponse> GetLastExpiringCertificates(int id)
        {

            var entity = _context.ViewCertificates.Where(q => q.PersonId == id && q.IsLast == 1 && q.Remain != null && q.Remain <= 30).OrderBy(q => q.ExpireStatus).ThenBy(q => q.Remain);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }
        public async Task<DataResponse> GetEmployeeCertificates(int id)
        {

            var entity = _context.ViewCertifications.Where(q => q.EmployeeId == id);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }

        public async Task<DataResponse> GetEmployeeCertificatesBytype(int id, int tid)
        {

            var entity = _context.ViewCertifications.Where(q => q.EmployeeId == id && q.TypeId == tid);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }
        public async Task<DataResponse> GetEmployeeCertificatesBytype2(int id, int tid)
        {

            var entity = _context.ViewCertifications.Where(q => q.EmployeeId == id && q.TypeId == tid);
            if (entity != null)
            {
                return new DataResponse()
                {
                    Data = entity,
                    IsSuccess = true
                };

            }
            else
            {
                return new DataResponse()
                {
                    Data = null,
                    IsSuccess = false
                };

            }
        }

        public async Task<DataResponse> DeleteCertificates(int id)
        {

            var certification = await _context.Certifications.FirstOrDefaultAsync(q => q.Id == id);
            if (certification != null)
                _context.Certifications.Remove(certification);

            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
            {

                return new DataResponse() { IsSuccess = true };
            }

            else
                return new DataResponse() { IsSuccess = false };
        }

        public async Task<DataResponse> SaveCertificates(Certification dto)
        {
            var entity = await _context.Certifications.FirstOrDefaultAsync(q => q.TypeId == dto.TypeId && q.EmployeeId == dto.EmployeeId && q.Id == dto.Id);

            if (entity == null)
            {
                entity = new Certification();
                _context.Certifications.Add(entity);
            }
            entity.TypeId = dto.TypeId;
            entity.TypeTitle = dto.TypeTitle;
            entity.Description = dto.Description;
            entity.DateIssue = dto.DateIssue;
            entity.DateExpire = dto.DateExpire;
            entity.DateIRValid = dto.DateIRValid;
            entity.AcTypeId = dto.AcTypeId;
            entity.Rating = dto.Rating;
            entity.Class = dto.Class;
            entity.Limitation = dto.Limitation;
            entity.EmployedBy = dto.EmployedBy;
            entity.EmployedById = entity.EmployedById;
            entity.Occupation = dto.Occupation;
            entity.Level = dto.Level;
            entity.EmployeeId = dto.EmployeeId;
            entity.PersonId = dto.PersonId;
            entity.AirPocket = dto.AirPocket;
            entity.Title = dto.Title;
            entity.No = dto.No;




            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
            {

                return new DataResponse() { IsSuccess = true, Data = entity };
            }

            else
                return new DataResponse() { IsSuccess = false };
        }

    }
}

