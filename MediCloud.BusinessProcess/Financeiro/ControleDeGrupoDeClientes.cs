using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeGrupoDeClientes
    {
        public static List<CLIENTE_GRUPO> BuscarContadoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CLIENTE_GRUPO.Where(x => x.GRUPO.Contains(prefix)
                                                      || x.NOMEFANTASIA.Contains(prefix)
                                                      || x.CIDADE.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_GRUPO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CLIENTE_GRUPO RecuperarGrupoDeCLientesPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_GRUPO.Any(x => x.IDCLIGRU == v))
                    return contexto.CLIENTE_GRUPO.Where(x => x.IDCLIGRU == v).First();
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

        public static void ExcluirGrupoDeCLientes(int codigoGrupoDeClientes)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_GRUPO.Any(x => x.IDCLIGRU == codigoGrupoDeClientes))
                    contexto.CLIENTE_GRUPO.Remove(contexto.CLIENTE_GRUPO.First(x => x.IDCLIGRU == codigoGrupoDeClientes));

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

        public static CLIENTE_GRUPO SalvarGrupoDeClientes(CLIENTE_GRUPO clienteGrupoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE_GRUPO clienteGrupoSalvo = new CLIENTE_GRUPO();

            try
            {

                if (clienteGrupoDAO.IDCLIGRU > 0)
                {
                    clienteGrupoSalvo = contexto.CLIENTE_GRUPO.First(x => x.IDCLIGRU == clienteGrupoDAO.IDCLIGRU);

                    clienteGrupoSalvo.BAIRRO = clienteGrupoDAO.BAIRRO;
                    clienteGrupoSalvo.CEP = clienteGrupoDAO.CEP;
                    clienteGrupoSalvo.CIDADE = clienteGrupoDAO.CIDADE;
                    clienteGrupoSalvo.CPFCNPJ = clienteGrupoDAO.CPFCNPJ;
                    clienteGrupoSalvo.ENDERECO = clienteGrupoDAO.ENDERECO;
                    clienteGrupoSalvo.ENTREGA = clienteGrupoDAO.ENTREGA;
                    clienteGrupoSalvo.GRUPO = clienteGrupoDAO.GRUPO;
                    clienteGrupoSalvo.IDBBCOBRANCA = clienteGrupoDAO.IDBBCOBRANCA;
                    clienteGrupoSalvo.IDCID = clienteGrupoDAO.IDCID;
                    clienteGrupoSalvo.IDFEC = clienteGrupoDAO.IDFEC;
                    clienteGrupoSalvo.IDFORPAG = clienteGrupoDAO.IDFORPAG;
                    clienteGrupoSalvo.IDROTA = clienteGrupoDAO.IDROTA;
                    clienteGrupoSalvo.IDSEG = clienteGrupoDAO.IDSEG;
                    clienteGrupoSalvo.IMPRIME = clienteGrupoDAO.IMPRIME;
                    clienteGrupoSalvo.INSCESTADUAL = clienteGrupoDAO.INSCESTADUAL;
                    clienteGrupoSalvo.INSCMUNICIPAL = clienteGrupoDAO.INSCMUNICIPAL;
                    clienteGrupoSalvo.NF = clienteGrupoDAO.NF;
                    clienteGrupoSalvo.NOMEFANTASIA = clienteGrupoDAO.NOMEFANTASIA;
                    clienteGrupoSalvo.OBSERVACOES = clienteGrupoDAO.OBSERVACOES;
                    clienteGrupoSalvo.OBSNF = clienteGrupoDAO.OBSNF;
                    clienteGrupoSalvo.TIPOCLIENTE = clienteGrupoDAO.TIPOCLIENTE;
                    clienteGrupoSalvo.TIPOEMPRESA = clienteGrupoDAO.TIPOEMPRESA;
                    clienteGrupoSalvo.UF = clienteGrupoDAO.UF;            

                }
                else
                {
                    clienteGrupoSalvo = contexto.CLIENTE_GRUPO.Add(clienteGrupoDAO);
                }

                contexto.SaveChanges();
                return clienteGrupoSalvo;

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

        public static void BloquearCrediarioDeGrupo(int codigoDoGrupo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.CLIENTE_CREDIARIO.Any(x => x.IDCLIGRU == codigoDoGrupo && x.STATUS == "S"))
                { 
                   foreach(CLIENTE_CREDIARIO item in contexto.CLIENTE_CREDIARIO.Where(x => x.IDCLIGRU == codigoDoGrupo))
                    {
                        item.STATUS = "N";
                    }
                }
                else if(contexto.CLIENTE_CREDIARIO.Any(x => x.IDCLIGRU == codigoDoGrupo && x.STATUS == "N"))
                {
                    foreach (CLIENTE_CREDIARIO item in contexto.CLIENTE_CREDIARIO.Where(x => x.IDCLIGRU == codigoDoGrupo))
                    {
                        item.STATUS = "S";
                    }
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
    }
}
