using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OTLOB_7aln_Core.Entities.Identity;

namespace OTLOB_7aln_Repository.Identity
{
    public class AppIdentityContext: IdentityDbContext<AppUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options):base(options)
        {

        }
    }
}
