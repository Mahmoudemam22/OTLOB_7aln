using System.ComponentModel.DataAnnotations;

namespace OTLOB_7aln_API.Dtos
{
    public class AddressDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
    }
}
