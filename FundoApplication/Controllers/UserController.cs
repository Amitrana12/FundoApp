// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundoApplication.Controllers
{
    using FundooModels;
    using FunduManger.Interface;
    using Microsoft.AspNetCore.Mvc;
    using StackExchange.Redis;
    using System;

    /// <summary>
    /// UserController class 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user
        /// </summary>
        private readonly IUserManager manager;
        /// <summary>
        /// The logger
        /// </summary>
        private ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userManager">user manager.</para
        public UserController(IUserManager manager, ILog logger)
        {
            this.manager = manager;
           this.logger = logger;
        }

        /// <summary>
        /// Registrations for registration the specified user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response data</returns>
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

        /// <summary>
        /// LoginEmployee for the existing user
        /// </summary>
        /// <param name="model">model as parameter</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("loginEmployee")]
        public ActionResult LoginEmployee(LoginModel model)
        {
            try
            {
                logger.Information("Information is logged");
                logger.Warning("Warnning is logged");
                logger.Debug("Debgue is logged");
                logger.Error("Error is logged");

                var result = this.manager.Login(model.Email, model.Password);   
                if (result.Equals(true))
                {
                   
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(key: "FundooToken", "Bearer "+this.manager.GenerateToken(model.Email));
                    string token= database.StringGet("FundooToken");
                    return this.Ok(new { Status = true, Message = "Login Sucessfully",data=token    });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to login the user :Email or Password mismatched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>response data</returns>
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

        /// <summary>
        /// Resets the password employee.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>response data</returns>
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
