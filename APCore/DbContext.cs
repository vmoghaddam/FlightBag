using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APCore.Models
{
    public partial class ppa_cspnContext
    {
        public async Task<SaveResult> SaveAsync()
        {
            try
            {
                
                await this.SaveChangesAsync();
                return new SaveResult()
                {
                    Succeed = true,
                    Error = null,
                    InnerError = null,
                };
            }
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {

            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            var xxx =
            //                 ve.PropertyName + " " + ve.ErrorMessage;
            //        }
            //    }
            //    return new CustomActionResult(HttpStatusCode.InternalServerError, "DbEntityValidationException");
            //}
            catch (DbUpdateException dbu)
            {
                var exception = Exceptions.HandleDbUpdateException(dbu);
                return new SaveResult()
                {
                     Succeed=false,
                     Error= exception,
                     InnerError=null,
                };
                
            }
            catch (Exception ex)
            {
                return new SaveResult()
                {
                    Succeed = false,
                    Error = ex,
                    InnerError = ex.InnerException,
                };
            }
        }
    }

    public class SaveResult
    {
        public bool Succeed { get; set; }
        public Exception Error { get; set; }
        public Exception InnerError { get; set; }
        
        public string ErrorMessage
        {
            get
            {
                if (Error == null)
                    return string.Empty;
                var msg = Error.Message;
                if (InnerError != null)
                    msg += "  Inner: " + InnerError.Message;
                return msg;
            }
        }
    }

    public class Exceptions
    {
        internal static Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }


         
    }


}
