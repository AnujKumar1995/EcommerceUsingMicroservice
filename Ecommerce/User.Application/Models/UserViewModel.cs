using System.ComponentModel.DataAnnotations;

namespace User.Application.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
