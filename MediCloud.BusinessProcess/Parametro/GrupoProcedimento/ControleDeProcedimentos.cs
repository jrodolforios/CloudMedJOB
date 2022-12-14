using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Parametro.GrupoProcedimento
{
    public class ControleDeProcedimentos
    {
        #region Public Methods

        public static List<PROCEDIMENTO> buscarCargosPorTermoEFornecedor(string prefix, int fornecedor, int tabela)
        {
            CloudMedContext contexto = new CloudMedContext();
            List<PROCEDIMENTO> procedimentosEncontrados = new List<PROCEDIMENTO>();
            try
            {
                List<PROCEDIMENTO> procedimentos = contexto.PROCEDIMENTO.Where(x => (x.PROCEDIMENTO1.Contains(prefix)
                || x.ABREVIADO.Contains(prefix))
                ).ToList();

                procedimentos.ForEach(x =>
                {
                    if (x.TABELAXFORNECEDORXPROCEDIMENTO.Any(y => y.IDFOR == fornecedor && y.IDTAB == tabela))
                        procedimentosEncontrados.Add(x);
                });
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<PROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return procedimentosEncontrados;
        }

        public static List<PROCEDIMENTO> buscarProcedimentoPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO.Where(x => x.PROCEDIMENTO1.Contains(prefix)
                || x.ABREVIADO.Contains(prefix)
                ).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<PROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal BuscarValorProcedimentoPorIDFornecedor(int procedimento, int fornecedor, int tabela)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.TABELAXFORNECEDORXPROCEDIMENTO.Any(x => x.IDPRO == procedimento && x.IDFOR == fornecedor && x.IDTAB == tabela))
                    return contexto.TABELAXFORNECEDORXPROCEDIMENTO.First(x => x.IDPRO == procedimento && x.IDFOR == fornecedor && x.IDTAB == tabela).FATURAMENTO;
                else
                    return 0;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarProcedimento(int codigoProcedimento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROCEDIMENTO.Any(x => x.IDPRO == codigoProcedimento))
                    contexto.PROCEDIMENTO.Remove(contexto.PROCEDIMENTO.First(x => x.IDPRO == codigoProcedimento));

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

        public static PROCEDIMENTO recuperarProcedimentoPorID(int idPro)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO.First(x => x.IDPRO == idPro);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROCEDIMENTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PROCEDIMENTO SalvarProcedimento(PROCEDIMENTO procedimentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            PROCEDIMENTO setorSalvo = new PROCEDIMENTO();

            try
            {
                if (procedimentoDAO.IDPRO > 0)
                {
                    setorSalvo = contexto.PROCEDIMENTO.First(x => x.IDPRO == procedimentoDAO.IDPRO);

                    setorSalvo.ABREVIADO = procedimentoDAO.ABREVIADO;
                    setorSalvo.CODNEXO = procedimentoDAO.CODNEXO;
                    setorSalvo.COMPLEMENTO = procedimentoDAO.COMPLEMENTO;
                    setorSalvo.CONFIRMARAUTOMATICO = procedimentoDAO.CONFIRMARAUTOMATICO;
                    setorSalvo.IDFOR = procedimentoDAO.IDFOR;
                    setorSalvo.IDPRF = procedimentoDAO.IDPRF;
                    setorSalvo.IDSUBGRUPRO = procedimentoDAO.IDSUBGRUPRO;
                    setorSalvo.PROCEDIMENTO1 = procedimentoDAO.PROCEDIMENTO1;
                    setorSalvo.ZERAAUTOMATICO = procedimentoDAO.ZERAAUTOMATICO;
                }
                else
                {
                    setorSalvo = contexto.PROCEDIMENTO.Add(procedimentoDAO);
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