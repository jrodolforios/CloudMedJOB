using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeProcedimentosMovimento
    {
        #region Public Methods

        public static List<MOVIMENTO_PROCEDIMENTO> buscarProcedimentoMovimento(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<MOVIMENTO_PROCEDIMENTO> funcionario = contexto.MOVIMENTO_PROCEDIMENTO.Where(x => x.MOVIMENTO.CLIENTE.NOMEFANTASIA.Contains(prefix) || x.MOVIMENTO.FUNCIONARIO.FUNCIONARIO1.Contains(prefix)).ToList();

                return funcionario;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static List<MOVIMENTO_PROCEDIMENTO> buscarProcedimentoMovimentoLaudo(string prefix, int IdFuncionario)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<MOVIMENTO_PROCEDIMENTO> funcionario = contexto.MOVIMENTO_PROCEDIMENTO.Where(x => (x.PROCEDIMENTO.PROCEDIMENTO1.Contains(prefix)) && (int)x.MOVIMENTO.IDFUN == IdFuncionario).ToList();

                return funcionario;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static MOVIMENTO_PROCEDIMENTO buscarProcedimentoMovimentoPorId(int codigoDoProcedimentoMovimento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.MOVIMENTO_PROCEDIMENTO.Any(x => x.IDMOVPRO == codigoDoProcedimentoMovimento))
                    return contexto.MOVIMENTO_PROCEDIMENTO.First(x => x.IDMOVPRO == codigoDoProcedimentoMovimento);
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

        public static List<MOVIMENTO_PROCEDIMENTO> buscarProcedimentosMovimentoPorIdMovimento(decimal idMov)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO_PROCEDIMENTO.Where(x => x.IDMOV == idMov).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO_PROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ConfirmarExame(string login, int codigoDoProcedimentoMovimento)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO_PROCEDIMENTO usuarioSalvo = new MOVIMENTO_PROCEDIMENTO();

            try
            {
                if (codigoDoProcedimentoMovimento > 0)
                {
                    usuarioSalvo = contexto.MOVIMENTO_PROCEDIMENTO.First(x => x.IDMOVPRO == codigoDoProcedimentoMovimento);

                    usuarioSalvo.DATAREALIZADO = DateTime.Now;
                    usuarioSalvo.USUARIOREALIZADO = login;
                }

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

        public static int ContagemDeConvocacoesNoMes()
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO_PROCEDIMENTO.Where(x => x.PROXEXAME.HasValue ? (x.PROXEXAME.Value.Month == DateTime.Now.Month && x.PROXEXAME.Value.Year == DateTime.Now.Year && x.PROXEXAME.Value != x.DATAEXAME.Value) : false).Select(x => x.MOVIMENTO.IDFUN).Distinct().Count();
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

        public static int ContagemProcedimentosNoMes()
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO_PROCEDIMENTO.Count(x => x.DATAEXAME.HasValue ? (x.DATAEXAME.Value.Month == DateTime.Now.Month && x.DATAEXAME.Value.Year == DateTime.Now.Year) : false);
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
                if (contexto.MOVIMENTO_PROCEDIMENTO.Any(x => x.IDMOVPRO == codigoProcedimento))
                    contexto.MOVIMENTO_PROCEDIMENTO.Remove(contexto.MOVIMENTO_PROCEDIMENTO.First(x => x.IDMOVPRO == codigoProcedimento));

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

        public static MOVIMENTO_PROCEDIMENTO SalvarProcedimentoMovimento(MOVIMENTO_PROCEDIMENTO procedimentoMovimentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO_PROCEDIMENTO usuarioSalvo = new MOVIMENTO_PROCEDIMENTO();

            if (!procedimentoMovimentoDAO.PROXEXAME.HasValue)
                procedimentoMovimentoDAO.PROXEXAME = procedimentoMovimentoDAO.DATAEXAME.HasValue ? (DateTime?)procedimentoMovimentoDAO.DATAEXAME.Value.AddYears(1) : null;

            procedimentoMovimentoDAO = CacularValorTotal(procedimentoMovimentoDAO);

            try
            {
                if (procedimentoMovimentoDAO.IDMOVPRO > 0)
                {
                    usuarioSalvo = contexto.MOVIMENTO_PROCEDIMENTO.First(x => x.IDMOVPRO == procedimentoMovimentoDAO.IDMOVPRO);

                    usuarioSalvo.DATAEXAME = procedimentoMovimentoDAO.DATAEXAME;
                    usuarioSalvo.DATAREALIZADO = procedimentoMovimentoDAO.DATAREALIZADO;
                    usuarioSalvo.DESCONTO = procedimentoMovimentoDAO.DESCONTO;
                    usuarioSalvo.IDFAT = procedimentoMovimentoDAO.IDFAT;
                    usuarioSalvo.IDFCX = procedimentoMovimentoDAO.IDFCX;
                    usuarioSalvo.IDFOR = procedimentoMovimentoDAO.IDFOR;
                    usuarioSalvo.IDMOV = procedimentoMovimentoDAO.IDMOV;
                    usuarioSalvo.IDPRF = procedimentoMovimentoDAO.IDPRF;
                    usuarioSalvo.IDPRO = procedimentoMovimentoDAO.IDPRO;
                    usuarioSalvo.OBSMOVTO = procedimentoMovimentoDAO.OBSMOVTO;
                    usuarioSalvo.OBSREALIZADO = procedimentoMovimentoDAO.OBSREALIZADO;
                    usuarioSalvo.PROXEXAME = procedimentoMovimentoDAO.PROXEXAME;
                    usuarioSalvo.TOTAL = procedimentoMovimentoDAO.TOTAL;
                    usuarioSalvo.USUARIO = procedimentoMovimentoDAO.USUARIO;
                    usuarioSalvo.USUARIOREALIZADO = procedimentoMovimentoDAO.USUARIOREALIZADO;
                    usuarioSalvo.VALOR = procedimentoMovimentoDAO.VALOR;
                }
                else
                {
                    usuarioSalvo = contexto.MOVIMENTO_PROCEDIMENTO.Add(procedimentoMovimentoDAO);
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



        #region Private Methods

        private static MOVIMENTO_PROCEDIMENTO CacularValorTotal(MOVIMENTO_PROCEDIMENTO procedimentoMovimentoDAO)
        {
            if (procedimentoMovimentoDAO == null)
                return null;
            else
            {
                if (procedimentoMovimentoDAO.VALOR.HasValue && procedimentoMovimentoDAO.DESCONTO.HasValue)
                    procedimentoMovimentoDAO.TOTAL = (procedimentoMovimentoDAO.VALOR - procedimentoMovimentoDAO.DESCONTO);

                return procedimentoMovimentoDAO;
            }
        }

        #endregion Private Methods
    }
}