using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediCloud.BusinessProcess.Util
{
    public class Util
    {
        public static string ApenasNumeros (string valor)
        {
            return new string(valor.Where(c => char.IsDigit(c)).ToArray()); ;
        }
    }
}