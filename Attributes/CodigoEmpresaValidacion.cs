namespace ApiRest.Attributes
{
    using System.Text.RegularExpressions;

    namespace ApiRest.Attributes
    {
        public static class CodigoEmpresaValidacion
        {
            private static readonly Regex CodigoRegex =
                new Regex(@"^[A-Z][A-Z0-9]{4,9}$"); // Primer letra, 4-9 caracteres alfanuméricos

            public static bool EsCodigoValido(string codigo)
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    return false;

                codigo = codigo.ToUpper().Trim();

                return CodigoRegex.IsMatch(codigo);
            }
        }
    }

}
