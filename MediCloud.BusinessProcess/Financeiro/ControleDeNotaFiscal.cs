using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeNotaFiscal
    {
        public static List<NOTAFISCAL> BuscarNotaFiscalPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.NOTAFISCAL.Where(x => x.RAZAOSOCIAL.Contains(prefix)
                                                   || x.DATAEMISSAO.ToString().Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<NOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static NOTAFISCAL RecuperarNotaFiscalPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.NOTAFISCAL.Any(x => x.IDNF == v))
                    return contexto.NOTAFISCAL.Where(x => x.IDNF == v).First();
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

        public static List<SLNOTAFISCAL> RecuperarDetalheDeNotaFiscal(int idNF)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.SLNOTAFISCAL.Where(x => x.IDNF == idNF).Distinct().ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<SLNOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NOTAFISCAL> RecuperarNotasFiscaisDeFaturamento(decimal idFaturamento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.NOTAFISCAL.Where(x => x.IDFAT == idFaturamento).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<NOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static void ExcluirNotaFiscal(int codigoDaNotaFiscal)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.NOTAFISCAL.Any(x => x.IDNF == codigoDaNotaFiscal))
                    contexto.NOTAFISCAL.Remove(contexto.NOTAFISCAL.First(x => x.IDNF == codigoDaNotaFiscal));

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

        public static NOTAFISCAL SalvarNotaFiscal(NOTAFISCAL z)
        {
            CloudMedContext contexto = new CloudMedContext();
            NOTAFISCAL setorSalvo = new NOTAFISCAL();

            try
            {
                if (z.IDNF > 0)
                {
                    setorSalvo = contexto.NOTAFISCAL.First(x => x.IDNF == z.IDNF);

                    setorSalvo.BAIRRO = z.BAIRRO;
                    setorSalvo.CEP = z.CEP;
                    setorSalvo.CIDADE = z.CIDADE;
                    setorSalvo.CPFCNPJ = z.CPFCNPJ;
                    setorSalvo.DATAEMISSAO = z.DATAEMISSAO;
                    setorSalvo.DATAVENCIMENTO = z.DATAVENCIMENTO;
                    setorSalvo.DESCONTONOPRAZO = z.DESCONTONOPRAZO;
                    setorSalvo.ENDERECO = z.ENDERECO;
                    setorSalvo.ENTREGA = z.ENTREGA;
                    setorSalvo.IDBBCOBRANCA = z.IDBBCOBRANCA;
                    setorSalvo.IDCID = z.IDCID;
                    setorSalvo.IDCLI = z.IDCLI;
                    setorSalvo.IDCLIGRU = z.IDCLIGRU;
                    setorSalvo.IDFAT = z.IDFAT;
                    setorSalvo.IDFORPAG = z.IDFORPAG;
                    setorSalvo.IMPRIME = z.IMPRIME;
                    setorSalvo.INSCESTADUAL = z.INSCESTADUAL;
                    setorSalvo.INSCMUNICIPAL = z.INSCMUNICIPAL;
                    setorSalvo.IRRFNF = z.IRRFNF;
                    setorSalvo.ISSNF = z.ISSNF;
                    setorSalvo.NF = z.NF;
                    setorSalvo.NUMNF = z.NUMNF;
                    setorSalvo.OBSNF = z.OBSNF;
                    setorSalvo.PISCOFINSCSSL = z.PISCOFINSCSSL;
                    setorSalvo.RAZAOSOCIAL = z.RAZAOSOCIAL;
                    setorSalvo.TOTALNOTA = z.TOTALNOTA;
                    setorSalvo.UF = z.UF;
                    
                }
                else
                {
                    setorSalvo = contexto.NOTAFISCAL.Add(z);
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
    }
}
