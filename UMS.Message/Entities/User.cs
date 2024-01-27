using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Messages.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        [Required(ErrorMessage = "Hobbies are required.")]
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}
