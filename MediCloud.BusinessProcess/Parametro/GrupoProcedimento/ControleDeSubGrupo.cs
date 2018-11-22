using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Parametro.GrupoProcedimento
{
    public class ControleDeSubGrupo
    {
        #region Public Methods

        public static void DeletarSubGrupo(int codigoDoSubGrupo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROCEDIMENTO_GRUPO_SUBGRUP.Any(x => x.IDSUBGRUPRO == codigoDoSubGrupo))
                    contexto.PROCEDIMENTO_GRUPO_SUBGRUP.Remove(contexto.PROCEDIMENTO_GRUPO_SUBGRUP.First(x => x.IDSUBGRUPRO == codigoDoSubGrupo));

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

        public static PROCEDIMENTO_GRUPO_SUBGRUP recuperarSubGrupoPorID(int idSubGrupo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO_GRUPO_SUBGRUP.First(x => x.IDSUBGRUPRO == idSubGrupo);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROCEDIMENTO_GRUPO_SUBGRUP();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PROCEDIMENTO_GRUPO_SUBGRUP> RecuperarSubGrupoPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO_GRUPO_SUBGRUP.Where(x => x.SUBGRUPO.Contains(termo)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<PROCEDIMENTO_GRUPO_SUBGRUP>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PROCEDIMENTO_GRUPO_SUBGRUP SalvarSubGrupo(PROCEDIMENTO_GRUPO_SUBGRUP subGrupoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            PROCEDIMENTO_GRUPO_SUBGRUP setorSalvo = new PROCEDIMENTO_GRUPO_SUBGRUP();

            try
            {
                if (subGrupoDAO.IDSUBGRUPRO > 0)
                {
                    setorSalvo = contexto.PROCEDIMENTO_GRUPO_SUBGRUP.First(x => x.IDSUBGRUPRO == subGrupoDAO.IDSUBGRUPRO);

                    setorSalvo.IDGRUPRO = subGrupoDAO.IDGRUPRO;
                    setorSalvo.IDSUBGRUPRO = subGrupoDAO.IDSUBGRUPRO;
                    setorSalvo.SUBGRUPO = subGrupoDAO.SUBGRUPO;
                }
                else
                {
                    setorSalvo = contexto.PROCEDIMENTO_GRUPO_SUBGRUP.Add(subGrupoDAO);
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