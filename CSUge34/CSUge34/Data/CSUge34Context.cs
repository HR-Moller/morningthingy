using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSUge34.Models;

namespace CSUge34.Data
{
    public class CSUge34Context : DbContext
    {
        public CSUge34Context (DbContextOptions<CSUge34Context> options)
            : base(options)
        {
        }

        public DbSet<CSUge34.Models.Movie> Movie { get; set; } = default!;
    }
}
