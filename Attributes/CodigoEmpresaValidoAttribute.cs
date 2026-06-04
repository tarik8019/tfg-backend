
using ApiRest.Attributes.ApiRest.Attributes;
using System.ComponentModel.DataAnnotations;
namespace ApiRest.Attributes
{


        public class CodigoEmpresaValidoAttribute : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if (value == null)
                    return false;

                return CodigoEmpresaValidacion.EsCodigoValido(value.ToString()!);
            }

            public override string FormatErrorMessage(string name)
            {
                return $"{name} no es un código de empresa válido.";
            }
        }
    

}
