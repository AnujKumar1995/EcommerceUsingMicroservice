using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace User.Domain.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email{get;set;}
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
