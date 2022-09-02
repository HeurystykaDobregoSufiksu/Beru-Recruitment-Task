using System.ComponentModel.DataAnnotations;
using BeruTask.Shared.Utils;

namespace BeruTask.Shared
{
    public class RequestModel
    {
        [Required]
        
        [DateValidator("endDate", false)]
        public DateTime startDate { get; set; } = DateTime.Now.AddDays(-1.0);

        [Required]
        
        [DateValidator("startDate", true)]
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
