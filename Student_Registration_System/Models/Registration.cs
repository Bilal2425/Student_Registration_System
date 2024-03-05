using System.ComponentModel.DataAnnotations;

namespace Student_Registration_System.Models
{
    public class Registration
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
