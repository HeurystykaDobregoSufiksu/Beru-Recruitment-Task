using System.ComponentModel.DataAnnotations;
using BeruTask.Shared.Utils;

namespace BeruTask.Shared
{
    public class RequestModel
    {
        [Required(ErrorMessage ="Field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date")]
        [DateValidator("endDate", false)]
        public DateTime startDate { get; set; } = DateTime.Now.AddDays(-1.0);

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.DateTime, ErrorMessage ="Invalid date")]
        [DateValidator("startDate", true)]
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
