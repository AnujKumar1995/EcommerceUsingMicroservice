
#region Import Packages
using System.ComponentModel.DataAnnotations;
#endregion

namespace User.Domain.Models
{
    public class UserModel
    {
        #region Properties
        [Key]
        public int UserId { get; set; }
        public string Email{get;set;}
        public string Password { get; set; }
        public string Role { get; set; }
        #endregion

    }
}
