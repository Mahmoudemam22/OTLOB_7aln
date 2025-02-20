using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OTLOB_7aln_Core.Entities.Identity;
using OTLOB_7aln_Repository.Data;

namespace OTLOB_7aln_Repository.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedUser(ILoggerFactory Ilogger, UserManager<AppUser> userManager)
        {
            try
            {
                if (userManager.Users.Any() == false)
                {
                    var user = new AppUser()
                    {
                        DisplayName = "Mahmoud Emam",
                        Email = "mahmoudemam028@gmail.com",
                        UserName = "mahmoudemam028"
                    };
                   await userManager.CreateAsync(user, "mahmoudemam028");
                }
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
