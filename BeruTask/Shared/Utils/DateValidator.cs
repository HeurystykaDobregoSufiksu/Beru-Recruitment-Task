using System.ComponentModel.DataAnnotations;

namespace BeruTask.Shared.Utils
{
    public class DateValidator : ValidationAttribute
    {
        private readonly string _variableName;
        private readonly bool _isFuture;
        private string _message = "Error occured";

        public DateValidator(string variableName, bool isFuture)
        {
            this._variableName = variableName;
            this._isFuture = isFuture;
        }

        protected override ValidationResult IsValid(object value,ValidationContext context)
        {
            
            object? obj = context.ObjectType.GetProperty(this._variableName).GetValue(context.ObjectInstance);
            if (obj != null && DateTime.TryParse(obj.ToString(), out DateTime result1) && DateTime.TryParse(value.ToString(), out DateTime result2))
            {
                if (DateTime.Compare(result2, DateTime.Now) == 1)
                {
                    this._message = "Date value should not be a future date";
                    return new ValidationResult(this._message, (IEnumerable<string>)new string[1] { context.MemberName });
                }
                var dayDiff = (result1 - result2).Days;
                if(Math.Abs(dayDiff) > 365)
                {
                    this._message = "Date span difference cannot be greater than 365 days";
                    return new ValidationResult(this._message, (IEnumerable<string>)new string[1] { context.MemberName });
                }
                else if (this._isFuture && dayDiff <= 0 || !this._isFuture && dayDiff >= 0)
                    return ValidationResult.Success;

                this._message = !this._isFuture ? "Start date value should not be later than end date" : "End date value should not be earlier than start date";
                return new ValidationResult(this._message, (IEnumerable<string>)new string[1]{ context.MemberName});
            }
           
            return new ValidationResult(this._message, (IEnumerable<string>)new string[1]
            {context.MemberName});
        }
    }
}
