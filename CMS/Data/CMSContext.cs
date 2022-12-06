using System;
using CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class CMSContext:DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> opt): base(opt)
        {

        }

        public DbSet<Complaint> Complaints { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
