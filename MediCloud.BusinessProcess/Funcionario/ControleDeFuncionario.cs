using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Funcionario
{
    public class ControleDeFuncionario
    {
        public static List<FUNCIONARIO> buscarFuncionario(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.FUNCIONARIO.ToList();
                }
                else
                {
                    return contexto.FUNCIONARIO.Where(x => x.FUNCIONARIO1.Contains(termo)
                        || x.CLIENTE.NOMEFANTASIA.Contains(termo)
                        || x.RG.Contains(termo)
                        || x.CTPS.Contains(termo)
                        || x.MATRICULA.Contains(termo)
                        || x.CLIENTE.RAZAOSOCIAL.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FUNCIONARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InativarFuncionario(int codigoDoFuncionario, bool inativar)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                FUNCIONARIO usuario = contexto.FUNCIONARIO.First(x => x.IDFUN == codigoDoFuncionario);
                usuario.INATIVO = inativar;

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

        public static void ExcluirFuncionario(int codigoDoFuncionario)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.FUNCIONARIO.Remove(contexto.FUNCIONARIO.First(x => x.IDFUN == codigoDoFuncionario));

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

        public static FUNCIONARIO buscarFuncionarioPorID(int codigoFuncionario)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                FUNCIONARIO funcionario = contexto.FUNCIONARIO.First(x => x.IDFUN == codigoFuncionario);

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

        public static FUNCIONARIO SalvarFuncionario(FUNCIONARIO funcionarioDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FUNCIONARIO funcionarioSalvo = new FUNCIONARIO();

            try
            {
                if (contexto.FUNCIONARIO.Any(x => x.FUNCIONARIO1 == funcionarioDAO.FUNCIONARIO1 && x.IDCLI == funcionarioDAO.IDCLI && x.IDFUN != funcionarioDAO.IDFUN))
                    throw new InvalidOperationException("Já existe um funcionário com este nome cadastrado para o cliente indicado.");


                if (funcionarioDAO.IDFUN > 0)
                {
                    funcionarioSalvo = contexto.FUNCIONARIO.First(x => x.IDFUN == funcionarioDAO.IDFUN);

                    funcionarioSalvo.CELULAR = funcionarioDAO.CELULAR;
                    funcionarioSalvo.CODNEXO = funcionarioDAO.CODNEXO;
                    funcionarioSalvo.CTPS = funcionarioDAO.CTPS;
                    funcionarioSalvo.ENDERECO = funcionarioDAO.ENDERECO;
                    funcionarioSalvo.FUNCIONARIO1 = funcionarioDAO.FUNCIONARIO1;
                    funcionarioSalvo.IDCLI = funcionarioDAO.IDCLI;
                    funcionarioSalvo.INATIVO = funcionarioDAO.INATIVO;
                    funcionarioSalvo.MATRICULA = funcionarioDAO.MATRICULA;
                    funcionarioSalvo.NASCIMENTO = funcionarioDAO.NASCIMENTO;
                    funcionarioSalvo.RG = funcionarioDAO.RG;
                    funcionarioSalvo.TELEFONE = funcionarioDAO.TELEFONE;

                }
                else
                {
                    funcionarioSalvo = contexto.FUNCIONARIO.Add(funcionarioDAO);
                }

                contexto.SaveChanges();
                return funcionarioSalvo;

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

        public static List<FUNCIONARIO> buscarFuncionariosDeClientePorTermo(string prefix, int idCliente)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<FUNCIONARIO> funcionario = contexto.FUNCIONARIO.Where(x => x.FUNCIONARIO1.Contains(prefix) && (int)x.IDCLI == idCliente).ToList();

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
    }
}
