// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FunduManger.Interface
{
    using FundooModels;

    /// <summary>
    /// IUserManager interface
    /// </summary>
    public interface IUserManager
    {

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddNewUser(RegisterModel userData);

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>return true or false</returns>
        public bool Login(string email, string password);

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>get token</returns>
        public string GenerateToken(string email);

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>return true or false</returns>
        public bool SendEmail(string emailAddress);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>return true or false</returns>
        public bool ResetPassword(ResetPassword resetPassword);
    }
}
