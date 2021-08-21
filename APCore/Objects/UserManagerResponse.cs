using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.Objects
{
    public class UserManagerResponse
    {
        public string access_token { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public object Data { get; set; }
        public List<string> Roles { get; set; }
        public List<string> RoleClaims { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string JobGrooup { get; set; }
        public string JobGroupCode { get; set; }
        public bool  IsCrew { get; set; }
        public bool IsCockpit { get; set; }
        public bool IsCabin { get; set; }
    }

    public class DataResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
    }
    
    public class AuthDataHelper
    {
        public static int GetEmployeeId (string userData)
        {
            var prts = userData.Split('*').ToList();
            return Convert.ToInt32(prts[0]);
        }
    }
}
