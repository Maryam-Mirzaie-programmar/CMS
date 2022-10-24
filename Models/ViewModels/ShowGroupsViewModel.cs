using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Models
{
    public class ShowGroupsViewModel
    {
        public int GroupId { get; set; }

        public string GroupTitle { get; set; }

        public int PageCount { get; set; }
    }
}