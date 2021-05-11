// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using Experimental.System.Messaging;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;


        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// EncryptPassword methode to encrypt password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>encoded data</returns>
        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encryptData = new byte[password.Length];
                encryptData = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encryptData);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
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
                password = EncryptPassword(password);
                var login = this.userContext.RegisterModels.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
                if (login != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>true or false</returns>
        public bool AddNewUser(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.Password = EncryptPassword(userData.Password);
                    this.userContext.RegisterModels.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (ArgumentNullException ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// SendEmail Method for the sending email
        /// </summary>
        /// <param name="emailAddress">email Address</param>
        /// <returns>return true or false</returns>
        public bool SendEmail(string emailAddress)
        {
            try
            {
                var checkEmail = this.userContext.RegisterModels.Where(x => x.Email == emailAddress).FirstOrDefault();

                if (checkEmail != null)
                {
                    SendMessage();
                    string body = receiverMessage();

                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("sushmita03rana@gmail.com");
                    message.To.Add(new MailAddress(emailAddress));
                    message.Subject = "Test";
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = body;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("sushmita03rana@gmail.com", "Sushmita@03");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// ResetPassword method
        /// </summary>
        /// <param name="resetPassword">reset Password</param>
        /// <returns>return true or false</returns>
        public bool ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var Entries = this.userContext.RegisterModels.FirstOrDefault(x => x.Email == resetPassword.Email);
                if (Entries != null)
                {
                    if (resetPassword.Password == resetPassword.ConfirmPassword)
                    {
                        Entries.Password = EncryptPassword(resetPassword.Password);
                        this.userContext.Entry(Entries).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// sender method for MSMQ
        /// </summary>
        public void SendMessage()
        {
            var body = "Click on following link to reset your credentials for Fundoo Notes App: ";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = body;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
        }

        /// <summary>
        /// receiver method for MSMQ
        /// </summary>
        public string receiverMessage()
        {
            MessageQueue reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string body = recieving.Body.ToString();
            return body;
        }

        /// <summary>
        /// GenerateToken method
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>token for specific email</returns>
        public string GenerateToken(string email)
        {
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Email",email)
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:SecureKey"])), SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

        }
    }
}
