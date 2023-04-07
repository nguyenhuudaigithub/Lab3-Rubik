using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab_3.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<Rubik> Rubiks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rubik>()
                .Property(e => e.gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Rubik>()
                .Property(e => e.hinh)
                .IsUnicode(false);
        }
    }
}
