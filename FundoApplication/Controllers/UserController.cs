using FundooModels;
using FunduManger.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        

        public UserController(IUserManager manager)
        {
            this.manager = manager;
           // this.logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel userData)
        {
            try
            {
                var result = this.manager.AddNewUser(userData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<RegisterModel>() { Status = true, Message = "New User Added Successfully !", Data=userData});
                }

                return this.BadRequest(new ResponseModel<RegisterModel>() { Status = false, Message = "Unable to Add New User" });

            }
            catch (Exception ex)
            {

                return this.NotFound(new { Status = false, Message = ex.Message });
            }
            
        }

        [HttpPost]
        [Route("loginEmployee")]
        public ActionResult LoginEmployee(LoginModel model)
        {
            try
            {
                
                var result = this.manager.Login(model.Email, model.Password);   
                if (result.Equals(true))
                {
                    string token = this.manager.GenerateToken(model.Email);
                    return this.Ok(new { Status = true, Message = "Login Sucessfully",data=token    });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to login the user :Email or Password mismatched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }



        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgotPassword(string emailAddress)
        {
            try
            {
                var result = this.manager.SendEmail(emailAddress);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Mail Sent Sucessfully", Data = emailAddress });
                }
                return this.BadRequest(new { Status = false, Message = "Email is not correct:Please enter valid email" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }


        [HttpPut]
        [Route("resetPassword")]
        public IActionResult ResetPasswordEmployee(ResetPassword resetPassword)
        {
            try
            {
                var result = this.manager.ResetPassword(resetPassword);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<ResetPassword>() { Status = true, Message = "Reset Password Link Sent Sucessfully", Data = resetPassword });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to reset password:Email not exist in database or password is not matched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
