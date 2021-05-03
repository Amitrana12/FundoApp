using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Interface
{
    public interface IUserManager
    {
        public bool AddNewUser(RegisterModel userData);

       public bool Login(string email, string password);


        public bool SendEmail(string emailAddress);


        public bool ResetPassword(ResetPassword resetPassword);
    }
}
