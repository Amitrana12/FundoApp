using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModels
{
   public class RegisterModel
    {   
        [Key]
        public int UserId { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
         public String LastName { get; set; }

        [Required]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "E-mail is not valid. Please Entet valid email")]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
