using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCloud.BusinessProcess.Util.Enum
{
    public class Cliente
    {
        public enum ASOReportEnum
        {
            indefinido = 0,
            imprimirComMedCoord = 1,
            imprimirReciboASO = 2,
            imprimirSemMedCoord = 3,
            imprimirListaDeProcedimentos = 4,
            imprimirFichaClinica = 5
        }
    }
}
