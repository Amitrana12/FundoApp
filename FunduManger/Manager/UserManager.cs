using FundooModels;
using FundooRepository.Interface;
using FunduManger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Manager
{
    public class UserManager :IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool AddNewUser(RegisterModel userData) {
            return this.repository.AddNewUser(userData);
        }

        public bool Login(string email, string password)
        {
            try
            {
                bool result = this.repository.Login(email, password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool SendEmail(string emailAddress)
        {
            try
            {
                bool result = this.repository.SendEmail(emailAddress);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                bool result = this.repository.ResetPassword(resetPassword);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
