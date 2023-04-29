using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Context
{
    public class LifeDbContext : DbContext
    {
        public LifeDbContext(DbContextOptions<LifeDbContext> options): base(options) 
        {

        }
        public DbSet<PolicyModel> policyTable { get; set; } //It should be plural
       // public DbSet<AdminModel> adminTables { get; set; }//It should be plural
        //public DbSet<UserModel> userTables { get; set; }//It should be plural
        //public DbSet<DocumentModel> documentTables { get; set; }//It should be plural
       // public DbSet<LoginModel> loginTables { get; set; }It should be plural
    }
}
