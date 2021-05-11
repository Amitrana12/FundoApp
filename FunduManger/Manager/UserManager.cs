// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FunduManger.Manager
{
    using FunduManger.Interface;
    using FundooModels;
    using FundooRepository.Interface;
    using System;

    /// <summary>
    /// UserManager class implementing interface IUserManager
    /// </summary>
    /// <seealso cref="FundooManager.Interface.IUserManager" />
    public class UserManager :IUserManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// return true or false
        /// </returns>
        public bool AddNewUser(RegisterModel userData) {
            return this.repository.AddNewUser(userData);
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>return true or false</returns>
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
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>get token</returns>
        public string GenerateToken(string email) {
            try
            {

                return this.repository.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>return true or false</returns>
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
        /// Resets the password.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>return true or false</returns>
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
