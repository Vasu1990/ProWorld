using ProWorldz.DL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL
{
    public class ProWorldzContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public ProWorldzContext() : base("ConnectionString")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<State> State { get; set; }
        public DbSet<UserPost> UserPost { get; set; }
        public DbSet<UserPostComment> UserPostComment { get; set; }
        public DbSet<UserQualification> UserQualification { get; set; }
        public DbSet<UserPersonalInfomation> UserPersonalInfomation { get; set; }
        public DbSet<UserGeneralInfomation> UserGeneralInfomation { get; set; }
        public DbSet<UserVideo> UserVideo { get; set; }





        public DbSet<UserProfessionalQualification> UserProfessionalQualification { get; set; }


        public DbSet<IndustryType> IndustryType { get; set; }

        public DbSet<Degree> Degree { get; set; }

    }
}
