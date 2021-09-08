using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models.LoginOrRegister
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Enter the Login(Email)")]
        public string Login { get; set; }
        [Required(ErrorMessage =" Enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password isn't valid")]
        public string ConfirmPassword { get; set; }
    }
}
