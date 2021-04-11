using API_ALB.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ALB.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
        {            
        }
        public DbSet<Customer> Customers{get;set;}
        
    }
}