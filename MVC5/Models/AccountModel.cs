using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace MVC5.Models
{
	public class AccountModel
    {
        private const int hashkey = 13;
		public class RegisterModel
		{
            
            public static void FakeHash()
            {
                // prevent timing attacks
                BCrypt.Net.BCrypt.HashPassword("", hashkey);
            }

			[Required(ErrorMessage = "Username is required")]
			[DisplayName("Username")]
			public string UserName { get; set; }

			[Required(ErrorMessage = "Password is Required")]
			[DisplayName("Password")]
			[DataType(DataType.Password)]
			[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
			public string PassWord { get; set; }

			[Required(ErrorMessage = "Password is Required")]
			[DisplayName("Password")]
			[DataType(DataType.Password)]
			[Compare("PassWord",ErrorMessage = "Password didnt match,Try again")]
			public string confirmPassWord { get; set; }

            public string passwordHash { get; set; }
            public bool checkhashpass { get; set; }

            public virtual string setPassword(string password)
            {
                passwordHash = BCrypt.Net.BCrypt.HashPassword(password, hashkey);
                return passwordHash;
            }

            public virtual bool verify(string password,string hash)
            {
                checkhashpass = BCrypt.Net.BCrypt.Verify(password,hash);
                return checkhashpass;
            }
		}

        public class LoginModel
        {
            [DisplayName("Username")]
            [Required(ErrorMessage = "Username is required!")]
            public string userName { get; set;  }

            [DisplayName("Password")]
            [Required(ErrorMessage = "Password is required!")]
            [DataType(DataType.Password)]
            public string passWorld { get; set; }
        }


	}
}