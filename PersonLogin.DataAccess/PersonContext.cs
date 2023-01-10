using Microsoft.EntityFrameworkCore;
using PersonLogin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLogin.DataAccess
{
    public class PersonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("server=DESKTOP-689VM7L;database=PersonApi; integrated security=true;");

        }

        public DbSet<Person> Persons { get; set; }
    }
}
