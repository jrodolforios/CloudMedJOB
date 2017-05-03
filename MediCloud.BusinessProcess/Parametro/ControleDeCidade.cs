using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeCidade
    {
        public static List<CIDADE> buscarCidadePorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<CIDADE> cargo = contexto.CIDADE.Where(x => x.CIDADE1.Contains(termo)
                                                             || x.ESTADO.Contains(termo)).ToList();

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

        public static CIDADE buscarCidadePorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CIDADE.Any(x => x.IDCID == v))
                    return contexto.CIDADE.First(x => x.IDCID == v);
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

        public static CIDADE SalvarCidade(CIDADE cidadeDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CIDADE setorSalvo = new CIDADE();

            try
            {

                if (cidadeDAO.IDCID > 0)
                {
                    setorSalvo = contexto.CIDADE.First(x => x.IDCID == cidadeDAO.IDCID);

                    setorSalvo.CIDADE1 = cidadeDAO.CIDADE1;
                    setorSalvo.CIDNF = cidadeDAO.CIDNF;
                    setorSalvo.ESTADO = cidadeDAO.ESTADO;

                }
                else
                {
                    setorSalvo = contexto.CIDADE.Add(cidadeDAO);
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

        public static void DeletarCidade(int codigoDoCidade)
        {
            CloudMedContext contexto = new CloudMedContext();
            CIDADE setorSalvo = new CIDADE();

            try
            {
                if (contexto.CIDADE.Any(x => x.IDCID == codigoDoCidade))
                    contexto.CIDADE.Remove(contexto.CIDADE.First(x => x.IDCID == codigoDoCidade));

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
