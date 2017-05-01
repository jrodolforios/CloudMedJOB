using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using MediCloud.BusinessProcess.Util;
using System.Data.Entity.Validation;

namespace MediCloud.BusinessProcess.Fornecedor
{
    public class ControleDeFornecedor
    {
        public static FORNECEDOR buscarProcedimentosMovimentoPorIdMovimento(int idFor)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.FORNECEDOR.Any(x => x.IDFOR == idFor))
                    return contexto.FORNECEDOR.First(x => x.IDFOR == idFor);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new FORNECEDOR();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FORNECEDOR> buscarFornecedorPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FORNECEDOR.Where(x => x.RAZAOSOCIAL.Contains(prefix)
                || x.NOMEFANTASIA.Contains(prefix)
                ).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FORNECEDOR>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarFornecedor(int codigoFornecedor)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.FORNECEDOR.Any(x => x.IDFOR == codigoFornecedor))
                    contexto.FORNECEDOR.Remove(contexto.FORNECEDOR.First(x => x.IDFOR == codigoFornecedor));

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

        public static FORNECEDOR SalvarFornecedor(FORNECEDOR fornecedorDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FORNECEDOR fornecedorSalvo = new FORNECEDOR();

            try
            {

                if (fornecedorDAO.IDFOR > 0)
                {
                    fornecedorSalvo = contexto.FORNECEDOR.First(x => x.IDFOR == fornecedorDAO.IDFOR);

                    fornecedorSalvo.BAIRRO = fornecedorDAO.BAIRRO;
                    fornecedorSalvo.CNPJ = fornecedorDAO.CNPJ;
                    fornecedorSalvo.CTAAGENCIA = fornecedorDAO.CTAAGENCIA;
                    fornecedorSalvo.CTABANCO = fornecedorDAO.CTABANCO;
                    fornecedorSalvo.CTACORRENTE = fornecedorDAO.CTACORRENTE;
                    fornecedorSalvo.ENDERECO = fornecedorDAO.ENDERECO;
                    fornecedorSalvo.NOMEFANTASIA = fornecedorDAO.NOMEFANTASIA;
                    fornecedorSalvo.RAZAOSOCIAL = fornecedorDAO.RAZAOSOCIAL;
                    fornecedorSalvo.TIPOCONTA = fornecedorDAO.TIPOCONTA;
                    fornecedorSalvo.TIPOFORNECEDOR = fornecedorDAO.TIPOFORNECEDOR;                    
                }
                else
                {
                    fornecedorSalvo = contexto.FORNECEDOR.Add(fornecedorDAO);
                }

                contexto.SaveChanges();
                return fornecedorSalvo;

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

        public static List<FORNECEDORXPROCEDIMENTO> recuperarProcedimentosDeFornecedor(int idFor)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.FORNECEDORXPROCEDIMENTO.Any(x => x.FORNECEDOR.IDFOR == idFor))
                    return contexto.FORNECEDORXPROCEDIMENTO.Where(x => x.FORNECEDOR.IDFOR == idFor).ToList();
                else
                    return new List<FORNECEDORXPROCEDIMENTO>();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FORNECEDORXPROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
