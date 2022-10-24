using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCms.Models
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(100)]
        public string Username { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { get; set; }
    }
}