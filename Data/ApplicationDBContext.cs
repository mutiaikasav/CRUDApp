using CRUDApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Data
{
    public class ApplicationDBContext: DbContext
    {
        public virtual DbSet<Employee> Employees{get;set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}