using System.ComponentModel.DataAnnotations;

namespace BeruTask.Client.Models
{
    public class RequestModel
    {
        [Required]
     
        public DateTime startDate { get; set; } = DateTime.Now.AddDays(-1.0);

        [Required]
       
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
