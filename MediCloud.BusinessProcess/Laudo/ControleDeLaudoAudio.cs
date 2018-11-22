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
    public class ControleDeLaudoAudio
    {
        #region Public Methods

        public static List<LAUDOAUD> buscarLaudoAudio(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return contexto.LAUDOAUD.ToList();
                }
                else
                {
                    return contexto.LAUDOAUD.Where(x => x.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.FUNCIONARIO1.Contains(prefix)
                    || x.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.CLIENTE.NOMEFANTASIA.Contains(prefix)
                    || x.MOVIMENTO_PROCEDIMENTO.PROCEDIMENTO.PROCEDIMENTO1.Contains(prefix)
                    || ((int)x.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.IDMOV).ToString() == prefix).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDOAUD>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LAUDOAUD BuscarLaudoAudioPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.LAUDOAUD.Any(x => (int)x.IDLAUDO == v))
                    return contexto.LAUDOAUD.First(x => (int)x.IDLAUDO == v);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new LAUDOAUD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirLaudoAudio(int codigoLaudoAudio)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.LAUDOAUD.Remove(contexto.LAUDOAUD.First(x => x.IDLAUDO == codigoLaudoAudio));

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

        public static byte[] ImprimirAudiometria(int codigoAudiometria)
        {
            LAUDOAUD audiometria = ControleDeLaudoAudio.BuscarLaudoAudioPorId(codigoAudiometria);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            LaudoReports Report = new LaudoReports(audiometria, Util.Enum.Laudo.LaudoReportEnum.imprimirAudiometria, infoClinica);

            return Report.generate();
        }

        public static LAUDOAUD SalvarLaudoAudio(LAUDOAUD LaudoAudioDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            LAUDOAUD laudoAudioSalvo = new LAUDOAUD();

            try
            {
                if (contexto.LAUDOAUD.Any(x => LaudoAudioDAO.IDLAUDO == x.IDLAUDO && LaudoAudioDAO.IDMOVPRO == x.IDMOVPRO))
                {
                    throw new InvalidOperationException("Já foi cadastrada uma audiometría para este Movimento.");
                }

                if (LaudoAudioDAO.IDLAUDO > 0)
                {
                    laudoAudioSalvo = contexto.LAUDOAUD.First(x => x.IDLAUDO == LaudoAudioDAO.IDLAUDO);

                    laudoAudioSalvo.DATAPROX = LaudoAudioDAO.DATAPROX;
                    laudoAudioSalvo.IDLAUDO = LaudoAudioDAO.IDLAUDO;
                    laudoAudioSalvo.IDMOVPRO = LaudoAudioDAO.IDMOVPRO;
                    laudoAudioSalvo.OBSERVACAO = LaudoAudioDAO.OBSERVACAO;

                    laudoAudioSalvo.OD250 = LaudoAudioDAO.OD250;
                    laudoAudioSalvo.OD500 = LaudoAudioDAO.OD500;
                    laudoAudioSalvo.OD1K = LaudoAudioDAO.OD1K;
                    laudoAudioSalvo.OD2K = LaudoAudioDAO.OD2K;
                    laudoAudioSalvo.OD3K = LaudoAudioDAO.OD3K;
                    laudoAudioSalvo.OD4K = LaudoAudioDAO.OD4K;
                    laudoAudioSalvo.OD6K = LaudoAudioDAO.OD6K;
                    laudoAudioSalvo.OD8K = LaudoAudioDAO.OD8K;

                    laudoAudioSalvo.ODO250 = LaudoAudioDAO.ODO250;
                    laudoAudioSalvo.ODO500 = LaudoAudioDAO.ODO500;
                    laudoAudioSalvo.ODO1K = LaudoAudioDAO.ODO1K;
                    laudoAudioSalvo.ODO2K = LaudoAudioDAO.ODO2K;
                    laudoAudioSalvo.ODO3K = LaudoAudioDAO.ODO3K;
                    laudoAudioSalvo.ODO4K = LaudoAudioDAO.ODO4K;
                    laudoAudioSalvo.ODO6K = LaudoAudioDAO.ODO6K;
                    laudoAudioSalvo.ODO8K = LaudoAudioDAO.ODO8K;

                    laudoAudioSalvo.OE250 = LaudoAudioDAO.OE250;
                    laudoAudioSalvo.OE500 = LaudoAudioDAO.OE500;
                    laudoAudioSalvo.OE1K = LaudoAudioDAO.OE1K;
                    laudoAudioSalvo.OE2K = LaudoAudioDAO.OE2K;
                    laudoAudioSalvo.OE3K = LaudoAudioDAO.OE3K;
                    laudoAudioSalvo.OE4K = LaudoAudioDAO.OE4K;
                    laudoAudioSalvo.OE6K = LaudoAudioDAO.OE6K;
                    laudoAudioSalvo.OE8K = LaudoAudioDAO.OE8K;

                    laudoAudioSalvo.OEO250 = LaudoAudioDAO.OEO250;
                    laudoAudioSalvo.OEO500 = LaudoAudioDAO.OEO500;
                    laudoAudioSalvo.OEO1K = LaudoAudioDAO.OEO1K;
                    laudoAudioSalvo.OEO2K = LaudoAudioDAO.OEO2K;
                    laudoAudioSalvo.OEO3K = LaudoAudioDAO.OEO3K;
                    laudoAudioSalvo.OEO4K = LaudoAudioDAO.OEO4K;
                    laudoAudioSalvo.OEO6K = LaudoAudioDAO.OEO6K;
                    laudoAudioSalvo.OEO8K = LaudoAudioDAO.OEO8K;
                }
                else
                {
                    laudoAudioSalvo = contexto.LAUDOAUD.Add(LaudoAudioDAO);
                }

                contexto.SaveChanges();
                return laudoAudioSalvo;
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