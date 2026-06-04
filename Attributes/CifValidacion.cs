namespace ApiRest.Attributes
{
    public static class CifValidacion
    {
        private static readonly string LetrasIniciales = "ABCDEFGHJUV";

        public static bool EsCifValido(string cif)
        {
            if (string.IsNullOrWhiteSpace(cif))
                return false;

            cif = cif.ToUpper().Trim();

            if (cif.Length != 9)
                return false;

            // Primera letra
            char letraInicial = cif[0];
            if (!LetrasIniciales.Contains(letraInicial))
                return false;

            // 7 dígitos centrales
            if (!int.TryParse(cif.Substring(1, 7), out int numero))
                return false;

            // Dígito/letra de control
            char control = cif[8];

            int sumaPares = 0;
            int sumaImpares = 0;

            for (int i = 1; i <= 7; i++)
            {
                int digito = int.Parse(cif[i].ToString());

                if (i % 2 == 0) // posición par
                {
                    sumaPares += digito;
                }
                else // posición impar
                {
                    int doble = digito * 2;
                    sumaImpares += (doble / 10) + (doble % 10);
                }
            }

            int total = sumaPares + sumaImpares;
            int unidad = total % 10;
            int digitoControl = (unidad == 0) ? 0 : 10 - unidad;

            // Si el control debe ser número
            if ("ABEH".Contains(letraInicial))
                return control == digitoControl.ToString()[0];

            // Si el control debe ser letra
            if ("KPQS".Contains(letraInicial))
                return control == "JABCDEFGHI"[digitoControl];

            // Si puede ser ambos
            return control == digitoControl.ToString()[0]
                || control == "JABCDEFGHI"[digitoControl];
        }
    }

}
