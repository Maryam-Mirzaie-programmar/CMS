using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCms.Models
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [MaxLength(150)]
        [Required(ErrorMessage = "لطفا فیلد '{0}' را وارد نمایید")]
        public string GroupTitle { get; set; }


        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {
        }
    }
}