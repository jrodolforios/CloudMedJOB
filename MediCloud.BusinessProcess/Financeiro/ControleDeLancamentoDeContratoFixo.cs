using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeLancamentoDeContratoFixo
    {
        #region Public Methods

        public static List<CONTRATO_FIXO_DET> BuscarDetalhesDeLancamento(int idLan)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CONTRATO_FIXO_DET.Where(x => x.IDLAN == idLan).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CONTRATO_FIXO_DET>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CONTRATO_FIXO BuscarLancamentoPorID(int? v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.CONTRATO_FIXO.Any(x => x.IDLAN == v))
                    return contexto.CONTRATO_FIXO.First(x => x.IDLAN == v);
                else
                    return null;
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

        public static List<CONTRATO_FIXO> BuscarLancamentoPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CONTRATO_FIXO.Where(x => x.FORNECEDOR.NOMEFANTASIA.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CONTRATO_FIXO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LancarMovimentos(int codigoDoLancamentoDeContrato)
        {
            CloudMedContext contexto = new CloudMedContext();
            CONTRATO_FIXO setorSalvo = new CONTRATO_FIXO();

            try
            {
                if (contexto.CONTRATO_FIXO.First(x => x.IDLAN == codigoDoLancamentoDeContrato).SITUACAO != "LAN")
                {
                    contexto.CONTRATO_FIXO.First(x => x.IDLAN == codigoDoLancamentoDeContrato).SITUACAO = "LAN";
                    contexto.SaveChanges();

                    contexto.Database.ExecuteSqlCommand($"EXEC CONTFIXO_LANMOV {codigoDoLancamentoDeContrato}");
                }
                else
                    throw new InvalidOperationException("Não é possível executar esta ação pois o contrato já foi lançado.");
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

        public static void RevisarDetalhes(int codigoDoLancamentoDeContrato)
        {
            CloudMedContext contexto = new CloudMedContext();
            CONTRATO_FIXO setorSalvo = new CONTRATO_FIXO();

            try
            {
                if (contexto.CONTRATO_FIXO.First(x => x.IDLAN == codigoDoLancamentoDeContrato).SITUACAO != "LAN")
                {
                    contexto.CONTRATO_FIXO.First(x => x.IDLAN == codigoDoLancamentoDeContrato).SITUACAO = "CON";
                    contexto.SaveChanges();

                    contexto.Database.ExecuteSqlCommand($"EXEC CONTFIXO_LANDET {codigoDoLancamentoDeContrato}");
                }
                else
                    throw new InvalidOperationException("Não é possível executar esta ação pois o contrato já foi lançado.");
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

        public static CONTRATO_FIXO SalvarLancamentoDeContrato(CONTRATO_FIXO contratoFixoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CONTRATO_FIXO setorSalvo = new CONTRATO_FIXO();

            try
            {
                if (contratoFixoDAO.IDLAN > 0)
                {
                    setorSalvo = contexto.CONTRATO_FIXO.First(x => x.IDLAN == contratoFixoDAO.IDLAN);

                    setorSalvo.DATA = contratoFixoDAO.DATA;
                    setorSalvo.DIA = contratoFixoDAO.DIA;
                    setorSalvo.IDFOR = contratoFixoDAO.IDFOR;
                    setorSalvo.QUANTIDADE = contratoFixoDAO.QUANTIDADE;
                    setorSalvo.SITUACAO = contratoFixoDAO.SITUACAO;
                    setorSalvo.TOTAL = contratoFixoDAO.TOTAL;
                    setorSalvo.USUARIO = contratoFixoDAO.USUARIO;
                }
                else
                {
                    setorSalvo = contexto.CONTRATO_FIXO.Add(contratoFixoDAO);
                }

                contexto.SaveChanges();
                return setorSalvo;
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