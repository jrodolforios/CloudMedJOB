namespace MediCloud.BusinessProcess.Util.Enum
{
    public class Cliente
    {
        #region Public Enums

        public enum ASOReportEnum
        {
            indefinido = 0,
            imprimirComMedCoord = 1,
            imprimirReciboASO = 2,
            imprimirSemMedCoord = 3,
            imprimirListaDeProcedimentos = 4,
            imprimirFichaClinica = 5,
            imprimirOrdemServicoASO = 6
        }

        public enum MovimentoReportEnum
        {
            indefinido = 0,
            imprimirRelatorioAnual = 1
        }

        #endregion Public Enums
    }
}