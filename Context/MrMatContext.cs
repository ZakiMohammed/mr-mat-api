using Microsoft.EntityFrameworkCore;
using mr_mat_api.Models;

namespace mr_mat_api.Context
{
    public class MrMatContext : DbContext
    {
        public MrMatContext(DbContextOptions<MrMatContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}