
#region Import Packages
using System.ComponentModel.DataAnnotations;
#endregion

namespace User.Application.Models
{
    public class UserViewModel
    {
        #region Properties
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public string Role { get; set; }
        #endregion
    }
}
