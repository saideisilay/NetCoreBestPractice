using App.Common;
using App.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        //product üzerinden old için product oluştururken illa ki productFeatures oluşacak o şekilde yapılabilir ama açık kalsın

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tek tek yapacağıma ayrı bir class'ta verilmesi daha doğru olur.
            //modelBuilder.Entity<Category>().HasKey(c => c.Id);

            //onun yerine configleri kaldırıp hepsini buraya tanıtmamız lazım assembly'ler hepsinde oluşturduğumuz class library'ler
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //yerine şu yapılabilir
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());   //çok fazla olması durumunda üsttekini yaparız
        }
    }
}
