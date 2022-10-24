using MyCms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyCms.Context
{
    public class CmsContext : DbContext
    {
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }

        public DbSet<AdminLogin> AdminLogins { get; set; }
    }
}