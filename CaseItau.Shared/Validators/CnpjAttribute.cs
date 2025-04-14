using System.ComponentModel.DataAnnotations;

namespace CaseItau.Shared.Validators
{
    public class CnpjAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return CnpjValidator.IsValid(value?.ToString());
        }
    }
}
