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
    public class ControleDeLaudoRX
    {
        #region Public Methods

        public static List<LAUDORX> buscarLaudoRX(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.LAUDORX.ToList();
                }
                else
                {
                    return contexto.LAUDORX.Where(x => x.MEDICO.Contains(termo)
                        || x.PACIENTE.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDORX>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LAUDORX buscarLaudoRXPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (v <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.LAUDORX.First(x => x.IDMOVPRO == v);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new LAUDORX();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarLaudoRX(int codigoRaioX)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                contexto.LAUDORX.Remove(contexto.LAUDORX.First(x => x.IDMOVPRO == codigoRaioX));

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
            LAUDORX laudoRX = ControleDeLaudoRX.buscarLaudoRXPorId(codigoLaudo);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            LaudoReports Report = new LaudoReports(laudoRX, Util.Enum.Laudo.LaudoReportEnum.imprimirLaudoRaioX, infoClinica);

            return Report.generate();
        }

        public static void LiberarLaudoRX(int codigoRaioX)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                LAUDORX laudoParaLiberar = contexto.LAUDORX.First(x => x.IDMOVPRO == codigoRaioX);

                laudoParaLiberar.STATUS = "LIBERADO";

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

        public static LAUDORX SalvarLaudo(LAUDORX laudoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            LAUDORX usuarioSalvo = new LAUDORX();

            try
            {
                if (laudoDAO.IDMOVPRO > 0)
                {
                    usuarioSalvo = contexto.LAUDORX.First(x => x.IDMOVPRO == laudoDAO.IDMOVPRO);

                    usuarioSalvo.CONCLUSAO = laudoDAO.CONCLUSAO;
                    usuarioSalvo.DATA = laudoDAO.DATA;
                    usuarioSalvo.IDADE = laudoDAO.IDADE;
                    usuarioSalvo.IDMODELO = laudoDAO.IDMODELO;
                    usuarioSalvo.IDMOVPRO = laudoDAO.IDMOVPRO;
                    usuarioSalvo.LAUDO = laudoDAO.LAUDO;
                    usuarioSalvo.LAUDONEGRITO = laudoDAO.LAUDONEGRITO;
                    usuarioSalvo.MEDICO = laudoDAO.MEDICO;
                    usuarioSalvo.PACIENTE = laudoDAO.PACIENTE;
                    usuarioSalvo.RODAPE = laudoDAO.RODAPE;
                    usuarioSalvo.STATUS = laudoDAO.STATUS;
                }
                else
                {
                    usuarioSalvo = contexto.LAUDORX.Add(laudoDAO);
                }

                contexto.SaveChanges();
                return usuarioSalvo;
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