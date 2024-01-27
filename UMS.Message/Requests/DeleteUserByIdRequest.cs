using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class DeleteUserByIdRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
