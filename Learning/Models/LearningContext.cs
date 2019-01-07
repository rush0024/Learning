using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Learning.Models
{
    public class LearningContext : DbContext
    {
        public LearningContext(DbContextOptions<LearningContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningPractise>()
                .Property(a => a.DateTime)
                .HasDefaultValueSql("getdate()");

        }

        public DbSet<LearningPractise> LearningPractises { get; set; }

    }
}
    