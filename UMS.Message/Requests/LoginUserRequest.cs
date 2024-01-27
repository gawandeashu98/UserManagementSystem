using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class LoginUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
