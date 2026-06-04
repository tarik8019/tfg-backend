using System.ComponentModel.DataAnnotations;
namespace ApiRest.Attributes
{
 

    public class CifValidoAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            return CifValidacion.EsCifValido(value.ToString()!);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} no es un CIF válido.";
        }
    }

}
