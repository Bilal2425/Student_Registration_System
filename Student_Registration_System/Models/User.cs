using System.ComponentModel.DataAnnotations;

namespace Student_Registration_System.Models
{
    public class User
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
        
    }
}
