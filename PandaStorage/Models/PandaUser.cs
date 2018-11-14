using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaStorage.Models
{
    public class PandaUser : IdentityUser
    {
        public PandaUser()
        {
            this.Packages = new HashSet<Package>();
        }

        public ICollection<Package> Packages { get; set; }
    }
}
