using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeDadosOcupacionais
    {
        public static List<CLIENTE_OCUPACIONAL> BuscarDadosOcupacionaisPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<CLIENTE_OCUPACIONAL> cargo = contexto.CLIENTE_OCUPACIONAL.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                                                                                       || (x.EPCMSO == null ? false : x.EPCMSO.ELABORADORPCMSO.Contains(termo))
                                                                                       || (x.IDEPPRA == null ? false : x.EPPRA.ELABORADORPPRA.Contains(termo))).ToList();

                return cargo;
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

        public static void DeletarDadosOcupacionais(int codigoDoDadosOcupacionais)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OCUPACIONAL.Any(x => x.IDCLIOC == codigoDoDadosOcupacionais))
                    contexto.CLIENTE_OCUPACIONAL.Remove(contexto.CLIENTE_OCUPACIONAL.First(x => x.IDCLIOC == codigoDoDadosOcupacionais));

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

        public static CLIENTE_OCUPACIONAL BuscarDadosOcupacionaisPorID(int codigoDoDadosOcupacionais)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OCUPACIONAL.Any(x => x.IDCLIOC == codigoDoDadosOcupacionais))
                    return contexto.CLIENTE_OCUPACIONAL.First(x => x.IDCLIOC == codigoDoDadosOcupacionais);
                else
                    return null;
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

        public static CLIENTE_OCUPACIONAL SalvarDadosOcupacionais(CLIENTE_OCUPACIONAL dadosOcupacionaisDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE_OCUPACIONAL dadosOcupacionaisSalvo = new CLIENTE_OCUPACIONAL();

            try
            {

                if (dadosOcupacionaisDAO.IDCLIOC > 0)
                {
                    dadosOcupacionaisSalvo = contexto.CLIENTE_OCUPACIONAL.First(x => x.IDCLIOC == dadosOcupacionaisDAO.IDCLIOC);

                    dadosOcupacionaisSalvo.CODNEXO = dadosOcupacionaisDAO.CODNEXO;
                    dadosOcupacionaisSalvo.EMISSAO = dadosOcupacionaisDAO.EMISSAO;
                    dadosOcupacionaisSalvo.IDEPCMSO = dadosOcupacionaisDAO.IDEPCMSO;
                    dadosOcupacionaisSalvo.IDEPPRA = dadosOcupacionaisDAO.IDEPPRA;
                    dadosOcupacionaisSalvo.NAODESEJA = dadosOcupacionaisDAO.NAODESEJA;
                    dadosOcupacionaisSalvo.OBSERVACAO = dadosOcupacionaisDAO.OBSERVACAO;
                    dadosOcupacionaisSalvo.PCMSO = dadosOcupacionaisDAO.PCMSO;
                    dadosOcupacionaisSalvo.VENCIMENTO = dadosOcupacionaisDAO.VENCIMENTO;
                    dadosOcupacionaisSalvo.IDCLI = dadosOcupacionaisDAO.IDCLI;
                    
                    
                }
                else
                {

                    dadosOcupacionaisSalvo = contexto.CLIENTE_OCUPACIONAL.Add(dadosOcupacionaisDAO);
                }

                contexto.SaveChanges();
                return dadosOcupacionaisSalvo;

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
    }
}
