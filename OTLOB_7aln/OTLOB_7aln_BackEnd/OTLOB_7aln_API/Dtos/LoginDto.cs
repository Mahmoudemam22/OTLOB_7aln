using System.ComponentModel.DataAnnotations;

namespace OTLOB_7aln_API.Dtos
{
    public class LoginDto
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
