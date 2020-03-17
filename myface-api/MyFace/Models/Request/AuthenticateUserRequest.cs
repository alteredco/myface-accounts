using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFace.Models.Request
{
    public class AuthenticateUserRequest
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}