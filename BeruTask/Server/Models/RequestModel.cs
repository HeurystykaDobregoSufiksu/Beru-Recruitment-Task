using System.ComponentModel.DataAnnotations;

namespace BeruTask.Server.Models
{
    public class RequestModel
    {
        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }
    }
}
