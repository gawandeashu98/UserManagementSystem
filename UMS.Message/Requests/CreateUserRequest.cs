using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage ="UserName is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int? Age { get; set; }
        public bool IsAdmin { get; set; }
        [Required(ErrorMessage = "Hobbies are required.")]
        public List<string>? Hobbies { get; set; }
    }
}
