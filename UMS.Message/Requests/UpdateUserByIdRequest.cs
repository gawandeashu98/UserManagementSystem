using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class UpdateUserByIdRequest
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}
