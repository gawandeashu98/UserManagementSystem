using System.ComponentModel.DataAnnotations;

namespace UMS.Messages.Requests
{
    public class GetUsersRequest
    {
        public PageRequest PageDetails { get; set; }
    }
    public class PageRequest
    {
        [Range(1, 1000)]
        [Required]
        public int? PageNumber { get; set; }
        [Range(1, 1000)]
        [Required]
        public int? PageSize { get; set; }
    }
}
