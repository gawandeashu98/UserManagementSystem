using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class GetUserByIdRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
