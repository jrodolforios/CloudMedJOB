using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Recomendacao
{
    public class ControleDeRiscoNatureza
    {
        #region Public Methods

        public static NATUREZA BuscarNaturezaPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            NATUREZA natureza = null;

            try
            {
                if (contexto.NATUREZA.Any(x => x.IDNAT == v))
                    natureza = contexto.NATUREZA.First(x => x.IDNAT == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return natureza;
        }

        public static List<NATUREZA> buscarNaturezaPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<NATUREZA> risco = contexto.NATUREZA.Where(x => x.NATUREZA1.Contains(termo)).ToList();

                return risco;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<NATUREZA>();
        }

        public static RISCO BuscarRiscoPorID(int codigoRisco)
        {
            CloudMedContext contexto = new CloudMedContext();
            RISCO natureza = null;

            try
            {
                if (contexto.RISCO.Any(x => x.IDRISCO == codigoRisco))
                    natureza = contexto.RISCO.First(x => x.IDRISCO == codigoRisco);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return natureza;
        }

        public static List<RISCO> buscarRiscoPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<RISCO> risco = contexto.RISCO.Where(x => x.RISCO1.Contains(prefix)
                                                           || x.NATUREZA.NATUREZA1.Contains(prefix)).ToList();

                return risco;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<RISCO>();
        }

        public static List<RISCO> BuscarRiscosPorIDNatureza(decimal idNat)
        {
            CloudMedContext contexto = new CloudMedContext();
            List<RISCO> riscos = new List<RISCO>();

            try
            {
                riscos = contexto.RISCO.Where(x => x.IDNAT == idNat).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return riscos;
        }

        public static List<RISCO> BuscarRiscosPorIDRecomendacao(int idRec)
        {
            CloudMedContext contexto = new CloudMedContext();
            List<RISCO> riscos = new List<RISCO>();

            try
            {
                List<RECOMENDACAOXRISCO> recomendacoesRisco = contexto.RECOMENDACAOXRISCO.Where(x => x.IDREC == idRec).ToList();

                recomendacoesRisco.ForEach(x =>
                {
                    riscos.AddRange(contexto.RISCO.Where(y => y.IDRISCO == x.IDRISCO).ToList());
                });
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return riscos;
        }

        public static void DeletarNatureza(int codigoNatureza)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.NATUREZA.Any(x => x.IDNAT == codigoNatureza))
                    contexto.NATUREZA.Remove(contexto.NATUREZA.First(x => x.IDNAT == codigoNatureza));

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

        public static void DeletarRisco(int codigoRisco)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.RISCO.Any(x => x.IDRISCO == codigoRisco))
                    contexto.RISCO.Remove(contexto.RISCO.First(x => x.IDRISCO == codigoRisco));

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

        public static NATUREZA RecuperarNaturezaPorID(int idNat)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.NATUREZA.Any(x => x.IDNAT == idNat))
                    return contexto.NATUREZA.First(x => x.IDNAT == idNat);
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

        public static NATUREZA SalvarNatureza(NATUREZA naturezaDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            NATUREZA naturezaSalva = new NATUREZA();

            try
            {
                if (naturezaDAO.IDNAT > 0)
                {
                    naturezaSalva = contexto.NATUREZA.First(x => x.IDNAT == naturezaDAO.IDNAT);

                    naturezaSalva.IDNAT = naturezaDAO.IDNAT;
                    naturezaSalva.NATUREZA1 = naturezaDAO.NATUREZA1;
                }
                else
                {
                    naturezaSalva = contexto.NATUREZA.Add(naturezaDAO);
                }

                contexto.SaveChanges();
                return naturezaSalva;
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

        public static RISCO SalvarRisco(RISCO riscoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            RISCO riscoSalvo = new RISCO();

            try
            {
                if (riscoDAO.IDRISCO > 0)
                {
                    riscoSalvo = contexto.RISCO.First(x => x.IDRISCO == riscoDAO.IDRISCO);

                    riscoSalvo.EVENTUALIDADE = riscoDAO.EVENTUALIDADE;
                    riscoSalvo.IDNAT = riscoDAO.IDNAT;
                    riscoSalvo.RISCO1 = riscoDAO.RISCO1;
                }
                else
                {
                    riscoSalvo = contexto.RISCO.Add(riscoDAO);
                }

                contexto.SaveChanges();
                return riscoSalvo;
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