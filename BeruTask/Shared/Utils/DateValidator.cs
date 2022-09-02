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
            object obj = context.ObjectType.GetProperty(this._variableName).GetValue(context.ObjectInstance);
            if (obj != null && DateTime.TryParse(obj.ToString(), out DateTime result1) && DateTime.TryParse(value.ToString(), out DateTime result2))
            {
                
                int num = DateTime.Compare(result1, result2);
                if (this._isFuture && num < 0 || !this._isFuture && num > 0)
                    return ValidationResult.Success;
                this._message = !this._isFuture ? "Start date cannot be later or equal to end date" : "End date cannot be earlier or equal to start date";
                return new ValidationResult(this._message, (IEnumerable<string>)new string[1]
                { context.MemberName});
            }
            return new ValidationResult(this._message, (IEnumerable<string>)new string[1]
            {context.MemberName});
        }
    }
}
