using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Context
{
    public class LifeDbContext : DbContext
    {
        public LifeDbContext(DbContextOptions<LifeDbContext> options): base(options) 
        {

        }
        public DbSet<PolicyModel> policyTable { get; set; }
        public DbSet<AdminModel> adminTable { get; set; }
        public DbSet<UserModel> userTable { get; set; }
        public object Usertable { get; internal set; }
        public DbSet<DocumentModel> documentTable { get; set; }
        public DbSet<LoginModel> loginTable { get; set; }

        public DbSet<PlanModel> planTable { get; set; }

        public DbSet<PaymentModel> paymentTable { get; set; }
    }
}
