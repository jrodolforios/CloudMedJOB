using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro.GrupoProcedimento
{
    public class ControleDeGrupo
    {
        public static PROCEDIMENTO_GRUPO recuperarSubGrupoPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO_GRUPO.First(x => x.IDGRUPRO == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROCEDIMENTO_GRUPO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarGrupo(int codigoDoGrupoProcedimento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROCEDIMENTO_GRUPO.Any(x => x.IDGRUPRO == codigoDoGrupoProcedimento))
                    contexto.PROCEDIMENTO_GRUPO.Remove(contexto.PROCEDIMENTO_GRUPO.First(x => x.IDGRUPRO == codigoDoGrupoProcedimento));

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

        public static List<PROCEDIMENTO_GRUPO> RecuperarGrupoPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<PROCEDIMENTO_GRUPO> grupo = contexto.PROCEDIMENTO_GRUPO.Where(x => x.GRUPOPROCEDIMENTO.Contains(termo)).ToList();

                return grupo;
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

        public static PROCEDIMENTO_GRUPO SalvarGrupo(PROCEDIMENTO_GRUPO grupoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            PROCEDIMENTO_GRUPO grupoSalvo = new PROCEDIMENTO_GRUPO();

            try
            {

                if (grupoDAO.IDGRUPRO > 0)
                {
                    grupoSalvo = contexto.PROCEDIMENTO_GRUPO.First(x => x.IDGRUPRO == grupoDAO.IDGRUPRO);

                    grupoSalvo.GRUPOPROCEDIMENTO = grupoDAO.GRUPOPROCEDIMENTO;

                }
                else
                {
                    grupoSalvo = contexto.PROCEDIMENTO_GRUPO.Add(grupoDAO);
                }

                contexto.SaveChanges();
                return grupoSalvo;
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
