using System.ComponentModel.DataAnnotations;
using BeruTask.Shared.Utils;

namespace BeruTask.Shared
{
    public class RequestModel
    {
        [Required]
        [DateValidation(ErrorMessage = "Date cannot be in the future")]
        [DateValidator("endDate", false)]
        public DateTime startDate { get; set; } = DateTime.Now.AddDays(-1.0);

        [Required]
        [DateValidation(ErrorMessage = "Date cannot be in the future")]
        [DateValidator("startDate", true)]
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
