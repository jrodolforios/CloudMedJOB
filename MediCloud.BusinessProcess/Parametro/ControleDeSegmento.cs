using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeSegmento
    {
        public static List<SEGMENTO> BuscarSegmentosPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.SEGMENTO.Where(x => x.SEGMENTO1.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<SEGMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SEGMENTO BuscarSegmentoPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;

            try
            {
                return contexto.SEGMENTO.First(x => x.IDSEG == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new SEGMENTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}