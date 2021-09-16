using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AAS.Data
{
    public class ProjectTemplateDbContextFactory : IDesignTimeDbContextFactory<AasDbContext>
    {
        public AasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AasDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=AAS;Trusted_Connection=True;MultipleActiveResultSets=True;");
            return new AasDbContext(optionsBuilder.Options);
        }
    }
}
