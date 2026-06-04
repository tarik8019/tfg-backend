using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiRest.Attributes
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        private static readonly Regex _regex =
            new Regex(@"^(?=.*[A-Z])(?=.*\d).{8,20}$", RegexOptions.Compiled);

        public override bool IsValid(object? value)
        {
            if (value is not string password)
                return false;

            return _regex.IsMatch(password);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be 8-20 characters long, contain at least one uppercase letter and one number.";
        }
    }
}
