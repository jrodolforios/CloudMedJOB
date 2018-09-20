using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeCrediarioCliente
    {
        #region Public Methods

        public static void BloquearCrediario(int codigoDoCrediario, bool bloquear)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.CLIENTE_CREDIARIO.Any(x => x.IDCRE == codigoDoCrediario))
                    contexto.CLIENTE_CREDIARIO.First(x => x.IDCRE == codigoDoCrediario).STATUS = bloquear ? "S" : "N";

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

        public static void ExcluirCrediarioCliente(int codigoCrediarioCliente)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_CREDIARIO.Any(x => x.IDCRE == codigoCrediarioCliente))
                    contexto.CLIENTE_CREDIARIO.Remove(contexto.CLIENTE_CREDIARIO.First(x => x.IDCRE == codigoCrediarioCliente));

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

        public static CLIENTE_CREDIARIO RecuperarCrediarioClientePorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_CREDIARIO.Any(x => x.IDCRE == v))
                    return contexto.CLIENTE_CREDIARIO.Where(x => x.IDCRE == v).First();
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

        public static List<CLIENTE_CREDIARIO> RecuperarCrediarioClientePorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CLIENTE_CREDIARIO.Where(x => x.CLIENTE.RAZAOSOCIAL.Contains(prefix)
                                                      || x.CLIENTE.NOMEFANTASIA.Contains(prefix)
                                                      || x.TABELA.TABELA1.Contains(prefix)
                                                      || x.MOVIMENTO_FECHAMENTO.PERIODO.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_CREDIARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CLIENTE_CREDIARIO> RecuperarCrediariosDeGrupoDeClientes(int idGrupoDeClientes)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CLIENTE_CREDIARIO.Where(x => x.IDCLIGRU == idGrupoDeClientes).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_CREDIARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CLIENTE_CREDIARIO SalvarCrediarioCliente(CLIENTE_CREDIARIO crediarioDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE_CREDIARIO setorSalvo = new CLIENTE_CREDIARIO();

            try
            {
                if (crediarioDAO.IDCRE > 0)
                {
                    setorSalvo = contexto.CLIENTE_CREDIARIO.First(x => x.IDCRE == crediarioDAO.IDCRE);

                    setorSalvo.BAIRRO = crediarioDAO.BAIRRO;
                    setorSalvo.CEP = crediarioDAO.CEP;
                    setorSalvo.CIDADE = crediarioDAO.CIDADE;
                    setorSalvo.CPFCNPJ = crediarioDAO.CPFCNPJ;
                    setorSalvo.ENDERECO = crediarioDAO.ENDERECO;
                    setorSalvo.ENTREGA = crediarioDAO.ENTREGA;
                    setorSalvo.IDBBCOBRANCA = crediarioDAO.IDBBCOBRANCA;
                    setorSalvo.IDCID = crediarioDAO.IDCID;
                    setorSalvo.IDCLI = crediarioDAO.IDCLI;
                    setorSalvo.IDCLIGRU = crediarioDAO.IDCLIGRU;
                    setorSalvo.IDCRE = crediarioDAO.IDCRE;
                    setorSalvo.IDFEC = crediarioDAO.IDFEC;
                    setorSalvo.IDFORPAG = crediarioDAO.IDFORPAG;
                    setorSalvo.IDTAB = crediarioDAO.IDTAB;
                    setorSalvo.IMPRIME = crediarioDAO.IMPRIME;
                    setorSalvo.INSCESTADUAL = crediarioDAO.INSCESTADUAL;
                    setorSalvo.INSCMUNICIPAL = crediarioDAO.INSCMUNICIPAL;
                    setorSalvo.NF = crediarioDAO.NF;
                    setorSalvo.OBSNF = crediarioDAO.OBSNF;
                    setorSalvo.SACADO = crediarioDAO.SACADO;
                    setorSalvo.STATUS = crediarioDAO.STATUS;
                    setorSalvo.TIPOEMPRESA = crediarioDAO.TIPOEMPRESA;
                    setorSalvo.UF = crediarioDAO.UF;
                    setorSalvo.USUARIO = crediarioDAO.USUARIO;
                }
                else
                {
                    setorSalvo = contexto.CLIENTE_CREDIARIO.Add(crediarioDAO);
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