using MediCloud.BusinessProcess.Laudo.Reports;
using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Laudo
{
    public class ControleDeLaudoVisao
    {
        #region Public Methods

        public static List<LAUDOAV> buscarLaudoAudio(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.LAUDOAV.ToList();
                }
                else
                {
                    return contexto.LAUDOAV.Where(x => x.FUNCIONARIO.FUNCIONARIO1.Contains(termo)
                    || x.CLIENTE.NOMEFANTASIA.Contains(termo)
                    || x.CARGO.CARGO1.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDOAV>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LAUDOAV buscarLaudoVisaoPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.LAUDOAV.Any(x => x.IDLAUDO == v))
                    return contexto.LAUDOAV.First(x => x.IDLAUDO == v);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new LAUDOAV();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirLaudoVisao(int codigoLaudoVisao)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.LAUDOAV.Remove(contexto.LAUDOAV.First(x => x.IDLAUDO == codigoLaudoVisao));

                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] ImprimirLaudo(int codigoLaudo)
        {
            LAUDOAV laudoVisao = ControleDeLaudoVisao.buscarLaudoVisaoPorId(codigoLaudo);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            LaudoReports Report = new LaudoReports(laudoVisao, Util.Enum.Laudo.LaudoReportEnum.imprimirLaudoVisao, infoClinica);

            return Report.generate();
        }

        public static LAUDOAV SalvarLaudoVisao(LAUDOAV s)
        {
            CloudMedContext contexto = new CloudMedContext();
            LAUDOAV a = new LAUDOAV();

            try
            {
                if (s.IDLAUDO > 0)
                {
                    a = contexto.LAUDOAV.First(x => x.IDLAUDO == s.IDLAUDO);

                    a.COD = s.COD;
                    a.COE = s.COE;
                    a.CONCLUSAO = s.CONCLUSAO;
                    a.CORRECAO = s.CORRECAO;
                    a.DATALAUDO = s.DATALAUDO;
                    a.ESTRABISMO = s.ESTRABISMO;
                    a.IDCGO = s.IDCGO;
                    a.IDCLI = s.IDCLI;
                    a.IDFUN = s.IDFUN;
                    a.OD = s.OD;
                    a.OE = s.OE;
                    a.VISAOCROMATICA = s.VISAOCROMATICA;
                }
                else
                {
                    a = contexto.LAUDOAV.Add(s);
                }

                contexto.SaveChanges();
                return a;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Methods
    }
}