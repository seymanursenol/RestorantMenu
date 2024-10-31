using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ng_server.Data.Entity;

namespace ng_server.Connected
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                    .HasOne(m=>m.Category)
                    .WithMany(c=>c.Menus)
                    .HasForeignKey(m=>m.CategoryId);

            base.OnModelCreating(modelBuilder);
        }

    }


}