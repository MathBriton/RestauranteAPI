using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestauranteAPI.Infrastructure.Context
{
    public class RestauranteContextFactory : IDesignTimeDbContextFactory<RestauranteContext>
    {
        public RestauranteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestauranteContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=RestauranteDB;Trusted_Connection=True;");

            return new RestauranteContext(optionsBuilder.Options);
        }
    }
}
