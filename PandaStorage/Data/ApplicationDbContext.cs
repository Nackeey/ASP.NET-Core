using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PandaStorage.Models;

namespace PandaStorage.Data
{
    public class ApplicationDbContext : IdentityDbContext<PandaUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}
