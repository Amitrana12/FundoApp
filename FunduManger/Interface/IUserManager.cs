

namespace FunduManger.Interface
{
    using FundooModels;

    public interface IUserManager
    {
        public bool AddNewUser(RegisterModel userData);

        public bool Login(string email, string password);

        public string GenerateToken(string email);

        public bool SendEmail(string emailAddress);

        public bool ResetPassword(ResetPassword resetPassword);
    }
}
