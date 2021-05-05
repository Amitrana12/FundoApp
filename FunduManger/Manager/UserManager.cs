
namespace FunduManger.Manager
{
    using FunduManger.Interface;
    using FundooModels;
    using FundooRepository.Interface;
    using System;
    
  
    public class UserManager :IUserManager
    {
        private readonly IUserRepository repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public bool AddNewUser(RegisterModel userData) {
            return this.repository.AddNewUser(userData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
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
