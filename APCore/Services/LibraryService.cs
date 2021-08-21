using APCore.Models;
using APCore.Objects;
using APCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APCore.Services
{
    public interface ILibraryService
    {
        Task<DataResponse> GetViewBookApplicableEmployee(int id, int cid, int? type = null);
        Task<DataResponse> GetLibraryEmployeeFolderCustomer(int pid, int fid, int eid, int cid);
        Task<DataResponse> VisitBookFile(int employeeId, int fileId);

    }
    public class LibraryService : ILibraryService
    {
        private readonly ppa_cspnContext _context;
        public LibraryService(ppa_cspnContext context)
        {
            _context = context;
        }
        public async Task<DataResponse> GetViewBookApplicableEmployee(int id, int cid, int? type = null)
        {
            List<ViewBookApplicableEmployee> data = null;
            if (type == null)
                data = await _context.ViewBookApplicableEmployees.Where(q => q.CustomerId == cid && q.EmployeeCustomerId == cid   && q.EmployeeId == id).OrderBy(q => q.IsVisited).ThenBy(q => q.IsDownloaded).ThenByDescending(q => q.DateExposure).ToListAsync();
            else
                data = await _context.ViewBookApplicableEmployees.Where(q => q.CustomerId == cid && q.EmployeeCustomerId == cid   && q.EmployeeId == id && q.TypeId == (int)type).OrderBy(q => q.IsVisited).ThenBy(q => q.IsDownloaded).ThenByDescending(q => q.DateExposure).ToListAsync();
           
            return new DataResponse
            {
                Data = data,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetLibraryEmployeeFolderCustomer(int pid, int fid, int eid, int cid)
        {
            int? parentId = pid == -1 ? null : (Nullable<int>)pid;
           
            var folders = await _context.ViewFolderApplicables.Where(q => q.CustomerId == cid && q.EmployeeCustomerId == cid && q.EmployeeId == eid && q.ParentId == parentId).OrderBy(q => q.FullCode).ToListAsync();
            
            var items = await _context.ViewBookApplicableEmployees.Where(q => q.CustomerId == cid && q.EmployeeCustomerId == cid && q.FolderId == fid && q.EmployeeId == eid).OrderBy(q => q.Title).ToListAsync();
            var ids = items.Select(q => q.BookId).ToList();
            
            var files = await _context.ViewBookFileVisiteds.Where(q => q.EmployeeId == eid && ids.Contains(q.BookId)).ToListAsync();
            var data = new
            {
                folders,
                items,
                files
            };

            return new DataResponse
            {
                Data = data,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> VisitBookFile(int employeeId, int fileId)
        {
            var status = await _context.BookFileVisits.Where(q => q.EmployeeId == employeeId && q.BookFileId == fileId).FirstOrDefaultAsync();
            if (status == null)
            {
                status = new BookFileVisit()
                {
                    EmployeeId = employeeId,
                    BookFileId = fileId,
                    DateVisited = DateTime.Now,

                };

                _context.BookFileVisits.Add(status);
                var save=await _context.SaveAsync();
            }
             

            return new DataResponse
            {
                Data = true,
                Errors = null,
                IsSuccess = true
            };
        }



    }
}
