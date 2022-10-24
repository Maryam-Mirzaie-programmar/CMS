using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Models
{
    public class ArchieveViewModel
    {
        public int PageId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string ImageName { get; set; }

        public DateTime CreateDate { get; set; }
    }
}