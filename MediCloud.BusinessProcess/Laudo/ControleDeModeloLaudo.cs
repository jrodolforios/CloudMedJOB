using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Laudo
{
    public class ControleDeModeloLaudo
    {
        public static List<MODELOLAUDO> buscarModeloLaudo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return contexto.MODELOLAUDO.ToList();
                }
                else
                {
                    return contexto.MODELOLAUDO.Where(x => x.MODELO.Contains(prefix)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MODELOLAUDO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MODELOLAUDO buscarModeloLaudoPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (v <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.MODELOLAUDO.First(x => (int)x.IDMODELO == v);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new MODELOLAUDO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirModeloLaudo(int codigoModeloLaudo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.MODELOLAUDO.Remove(contexto.MODELOLAUDO.First(x => x.IDMODELO == codigoModeloLaudo));

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

        public static MODELOLAUDO SalvarModeloLaudo(MODELOLAUDO modeloLaudoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MODELOLAUDO modeloSalvo = new MODELOLAUDO();

            try
            {

                if (modeloLaudoDAO.IDMODELO > 0)
                {
                    modeloSalvo = contexto.MODELOLAUDO.First(x => x.IDMODELO == modeloLaudoDAO.IDMODELO);

                    modeloSalvo.CONCLUSAO = modeloLaudoDAO.CONCLUSAO;
                    modeloSalvo.LAUDO = modeloLaudoDAO.LAUDO;
                    modeloSalvo.MODELO = modeloLaudoDAO.MODELO;
                    modeloSalvo.RODAPE = modeloLaudoDAO.RODAPE;

                }
                else
                {
                    modeloSalvo = contexto.MODELOLAUDO.Add(modeloLaudoDAO);
                }

                contexto.SaveChanges();
                return modeloSalvo;

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
