using Microsoft.AspNetCore.Identity;

namespace OTLOB_7aln_Core.Entities.Identity;

public class AppUser: IdentityUser
{
    public string DisplayName { get; set; }
    public Address Address { get; set; }
}
