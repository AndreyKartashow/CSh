using Microsoft.EntityFrameworkCore;
using  WebTestITDevelopment.Models;

namespace WebTestITDevelopment.Data
{
    public class MvcTaskContext : DbContext
    {
        public MvcTaskContext(DbContextOptions<MvcTaskContext> options)
            : base(options)
        {
        }

        public DbSet<TaskNote> TaskDB { get; set; }
    }
}
