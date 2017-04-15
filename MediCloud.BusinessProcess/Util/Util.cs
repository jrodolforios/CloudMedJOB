using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediCloud.BusinessProcess.Util
{
    public class Util
    {
        public static string ApenasNumeros(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
                return new string(valor.Where(c => char.IsDigit(c)).ToArray());
            else
                return null;
        }
        public static int CalcularIdade(DateTime? nascimento)
        {
            if (nascimento.HasValue)
            {
                // Save today's date.
                var today = DateTime.UtcNow;
                // Calculate the age.
                var age = today.Year - nascimento.Value.Year;
                // Do stuff with it.
                if (nascimento > today.AddYears(-age)) age--;

                return age;
            }
            else
                return -1;
        }
    }
}