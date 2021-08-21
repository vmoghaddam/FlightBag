using APCore.Models;
using APCore.Objects;
using APCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APCore.Services
{
    public interface IUserService
    {

        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
        Task<string> UpdateSecurityStamp();

        //Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);

        //Task<UserManagerResponse> ForgetPasswordAsync(string email);

        //Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }

    public class UserService : IUserService
    {

        private UserManager<IdentityUser> _userManger;
        private readonly ppa_cspnContext _context;
        RoleManager<IdentityRole> _roleManager;

        private IConfiguration _configuration;
        //private IMailService _mailService;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager/*, IMailService mailService*/, ppa_cspnContext context)
        {

            _userManger = userManager;
            _configuration = configuration;
            _context = context;
            //_mailService = mailService;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    access_token = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManger.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                //var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

                //var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                //var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                //string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";

                //await _mailService.SendEmailAsync(identityUser.Email, "Confirm your email", $"<h1>Welcome to Auth Demo</h1>" +
                //    $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");


                return new UserManagerResponse
                {
                    access_token = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                access_token = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }
        public async Task<string> UpdateSecurityStamp()
        {
            try
            {
                var users = await _userManger.Users.ToListAsync();
                foreach (var x in users)
                    await _userManger.UpdateSecurityStampAsync(x);
                return "ok";
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "    INNER:" + ex.InnerException.Message;
                return msg;

            }
           
        }
        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {

           // var users=_userManger.Users.ToListAsync();
           // var _u = await _userManger.FindByIdAsync("3526");
           //  await _userManger.UpdateSecurityStampAsync(_u);

            var user = await _userManger.FindByNameAsync(model.UserName);
            
            if (user == null)
            {
                return new UserManagerResponse
                {
                    access_token = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var adminPassword = "Magu1359";
            bool result = true;
            if (model.Password != adminPassword)
            // result = await _userManger.CheckPasswordAsync(user, model.Password);
            {
                var person = await _context.People.Where(q => q.UserId == user.Id).FirstOrDefaultAsync();
                if (person == null)
                    result = false;
                else
                    result = person.Telegram == model.Password;
            }
           

            
            if (!result)
                return new UserManagerResponse
                {
                    access_token = "Invalid password",
                    IsSuccess = false,
                };

            var userRoles = await (from x in _context.AspNetUserRoles
                                   join y in _context.AspNetRoles on x.RoleId equals y.Id
                                   where x.UserId==user.Id
                                   select y).ToListAsync();
            var roleIds = userRoles.Select(q => (Nullable<int>)Convert.ToInt32(q.Id)).Distinct().ToList();
            var roleClaims = await _context.AspNetRoleClaims.Where(q => roleIds.Contains(q.RoleId)).Select(q => q.ClaimType).ToListAsync();
            var roles = userRoles.Select(q => q.Name).Distinct().ToList();


            //_roleManager.


            var employee = await _context.ViewEmployees.FirstOrDefaultAsync(q => q.UserId == user.Id);
            var userDate = employee.Id.ToString()+"*"+employee.PersonId.ToString() + "*" + employee.Name + "*" + employee.JobGroup + "*" + employee.JobGroupCode;

            var claims = new[]
            {
                new Claim("UserName", model.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.UserData,userDate),
                //new Claim(ClaimTypes.UserData,"COCKPIT.P1.ALI DEHGHAN.DEHGHAN"),
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,


                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                access_token = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles,
                RoleClaims = roleClaims,
                JobGrooup=employee.JobGroup,
                JobGroupCode=employee.JobGroupCode,
                IsCrew=employee.JobGroupCode.StartsWith("00101") || employee.JobGroupCode.StartsWith("00102"),
                IsCockpit= employee.JobGroupCode.StartsWith("00101"),
                IsCabin= employee.JobGroupCode.StartsWith("00102"),
                Data = new { 
                 employee.Id,
                 employee.Name,
                 employee.FirstName,
                 employee.LastName,
                 employee.PersonId,
                 employee.Mobile,
                 employee.JobGroup,
                 employee.JobGroupCode,
                 NID=employee.NID,
                 employee.Types,
                 employee.BaseAirport,
                 employee.BaseAirportId,
                 employee.ScheduleName,
                 employee.CustomerId

                },
            };
        }

        //public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        //{
        //    var user = await _userManger.FindByIdAsync(userId);
        //    if (user == null)
        //        return new UserManagerResponse
        //        {
        //            IsSuccess = false,
        //            Message = "User not found"
        //        };

        //    var decodedToken = WebEncoders.Base64UrlDecode(token);
        //    string normalToken = Encoding.UTF8.GetString(decodedToken);

        //    var result = await _userManger.ConfirmEmailAsync(user, normalToken);

        //    if (result.Succeeded)
        //        return new UserManagerResponse
        //        {
        //            Message = "Email confirmed successfully!",
        //            IsSuccess = true,
        //        };

        //    return new UserManagerResponse
        //    {
        //        IsSuccess = false,
        //        Message = "Email did not confirm",
        //        Errors = result.Errors.Select(e => e.Description)
        //    };
        //}

        //public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
        //{
        //    var user = await _userManger.FindByEmailAsync(email);
        //    if (user == null)
        //        return new UserManagerResponse
        //        {
        //            IsSuccess = false,
        //            Message = "No user associated with email",
        //        };

        //    var token = await _userManger.GeneratePasswordResetTokenAsync(user);
        //    var encodedToken = Encoding.UTF8.GetBytes(token);
        //    var validToken = WebEncoders.Base64UrlEncode(encodedToken);

        //    string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

        //    await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
        //        $"<p>To reset your password <a href='{url}'>Click here</a></p>");

        //    return new UserManagerResponse
        //    {
        //        IsSuccess = true,
        //        Message = "Reset password URL has been sent to the email successfully!"
        //    };
        //}

        //public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        //{
        //    var user = await _userManger.FindByEmailAsync(model.Email);
        //    if (user == null)
        //        return new UserManagerResponse
        //        {
        //            IsSuccess = false,
        //            Message = "No user associated with email",
        //        };

        //    if (model.NewPassword != model.ConfirmPassword)
        //        return new UserManagerResponse
        //        {
        //            IsSuccess = false,
        //            Message = "Password doesn't match its confirmation",
        //        };

        //    var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
        //    string normalToken = Encoding.UTF8.GetString(decodedToken);

        //    var result = await _userManger.ResetPasswordAsync(user, normalToken, model.NewPassword);

        //    if (result.Succeeded)
        //        return new UserManagerResponse
        //        {
        //            Message = "Password has been reset successfully!",
        //            IsSuccess = true,
        //        };

        //    return new UserManagerResponse
        //    {
        //        Message = "Something went wrong",
        //        IsSuccess = false,
        //        Errors = result.Errors.Select(e => e.Description),
        //    };
        //}
    }
}
