using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQuizAddPersonData
{
    public class PersonDBContext:DbContext
    {
        public PersonDBContext()
        {

        }
        public virtual DbSet<Person> people { get; set; }
        public virtual DbSet<Passport> passports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Car & Rntal entity
            modelBuilder.Entity<Person>()
                        .HasOptional(p => p.Passport) // Mark Passport property optional in Person entity
                        .WithRequired(ps => ps.Person); // mark Person property as required in Passport entity. Cannot save Passport without Person
        }
    }
}
