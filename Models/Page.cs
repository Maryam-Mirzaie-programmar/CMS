using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCms.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(250)]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد نمایید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(350)]
        public string Tags { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "بازدید")]
        public int Visits { get; set; }

        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }


        public virtual PageGroup PageGroup { get; set; }
        public virtual List<PageComment> Comments { get; set; }
        public Page()
        {
        }
    }
}