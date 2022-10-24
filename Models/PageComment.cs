using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCms.Models
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        public int PageId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }



        public virtual Page Page { get; set; }
        public PageComment()
        {
        }
    }
}
