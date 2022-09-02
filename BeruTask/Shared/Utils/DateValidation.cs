using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeruTask.Shared.Utils
{
    public class DateValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (DateTime.TryParse(value.ToString(),out DateTime date))
            {
                if (DateTime.Compare(date, DateTime.Now) < 1) return true;
            }
            return false;
        }
    }
}
