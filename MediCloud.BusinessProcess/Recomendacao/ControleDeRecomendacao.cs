﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Recomendacao
{
    public class ControleDeRecomendacao
    {
        public static List<RECOMENDACAO> buscarRecomendacaoPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<RECOMENDACAO> recomendacao = contexto.RECOMENDACAO.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                                                                         || x.CLIENTE.RAZAOSOCIAL.Contains(termo)
                                                                         || x.CARGO.CARGO1.Contains(termo)
                                                                         || x.SETOR.SETOR1.Contains(termo)).ToList();

                return recomendacao;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<RECOMENDACAO>();
        }

        public static void DeletarRecomendacao(int codigoDaRecomendacao)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if(contexto.RECOMENDACAO.Any(x => x.IDREC == codigoDaRecomendacao))
                {
                    contexto.RECOMENDACAO.Remove(contexto.RECOMENDACAO.First(x => x.IDREC == codigoDaRecomendacao));
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

        public static RECOMENDACAO BuscarRecomendacaoProID(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAO recomendacao = null;
            try
            {
                if (contexto.RECOMENDACAO.Any(x => x.IDREC == idRef))
                    recomendacao = contexto.RECOMENDACAO.First(x => x.IDREC == idRef);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recomendacao;
        }

        public static Dictionary<MOVIMENTO_REFERENTE, List<PROCEDIMENTO>> RecuperarReferenciasProcedimentosDeRecomendacao(decimal idRec)
        {
            CloudMedContext contexto = new CloudMedContext();
            Dictionary<MOVIMENTO_REFERENTE, List<PROCEDIMENTO>> referenciasEProcedimentos = new Dictionary<MOVIMENTO_REFERENTE, List<PROCEDIMENTO>>();
            try
            {
                List<RECOMENDACAOXASO> ReferenciasLink = contexto.RECOMENDACAOXASO.Where(x => x.IDREC == idRec).ToList();

                ReferenciasLink.ForEach(x => 
                {
                    List<MOVIMENTO_REFERENTE> Referencias = contexto.MOVIMENTO_REFERENTE.Where(y => y.IDREF == x.IDREF).ToList();

                    Referencias.ForEach(y =>
                    {
                        List<RECOMENDACAOXASOXPRO> ReferenciasProcedimentosLink = contexto.RECOMENDACAOXASOXPRO.Where(z => z.IDRECASO == x.IDRECASO).ToList();
                        List<PROCEDIMENTO> ProcedimentosDeReferencia = new List<PROCEDIMENTO>();

                        ReferenciasProcedimentosLink.ForEach(z => 
                        {
                            ProcedimentosDeReferencia.AddRange(contexto.PROCEDIMENTO.Where(w => w.IDPRO == z.IDPRO).ToList());
                        });

                        referenciasEProcedimentos.Add(y, ProcedimentosDeReferencia);
                    });
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

            return referenciasEProcedimentos;
        }

        public static void DeletarProcedimento(int codigoRecomendacao, int codigoReferencia, int codigoprocedimento)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAOXASO recomendacaoReferente = recuperarRcomendacaoReferente(codigoRecomendacao, codigoReferencia);

            try
            {

                if (contexto.RECOMENDACAOXASOXPRO.Any(x => x.IDRECASO == recomendacaoReferente.IDRECASO && x.IDPRO == codigoprocedimento))
                {
                    contexto.RECOMENDACAOXASOXPRO.Remove(contexto.RECOMENDACAOXASOXPRO.First(x => x.IDRECASO == recomendacaoReferente.IDRECASO && x.IDPRO == codigoprocedimento));
                    contexto.SaveChanges();
                }
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

        public static void DeletarReferenciaDeRecomendacao(int codigoRecomendacao, int codigoReferencia)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                RECOMENDACAOXASO recomendacaoReferente = recuperarRcomendacaoReferente(codigoRecomendacao, codigoReferencia);

                if(recomendacaoReferente != null)
                {
                    contexto.RECOMENDACAOXASO.Remove(contexto.RECOMENDACAOXASO.First(x => x.IDRECASO == recomendacaoReferente.IDRECASO));
                    contexto.SaveChanges();
                }
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

        public static void DeletarRisco(int codigoDoRecomendacao, int codigoRisco)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {

                if (contexto.RECOMENDACAOXRISCO.Any(x => x.IDREC == codigoDoRecomendacao && x.IDRISCO == codigoRisco))
                {
                    contexto.RECOMENDACAOXRISCO.Remove(contexto.RECOMENDACAOXRISCO.First(x => x.IDREC == codigoDoRecomendacao && x.IDRISCO == codigoRisco));
                    contexto.SaveChanges();
                }
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

        public static void AdicionarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAOXASO recomendacaoReferente = null;

            try
            {

                if (!contexto.RECOMENDACAOXASO.Any(x => x.IDREC == codigoRecomendacao && x.IDREF == codigoReferencia))
                {
                    recomendacaoReferente = new RECOMENDACAOXASO();

                    recomendacaoReferente.IDREF = codigoReferencia;
                    recomendacaoReferente.IDREC = codigoRecomendacao;

                    contexto.RECOMENDACAOXASO.Add(recomendacaoReferente);
                    contexto.SaveChanges();
                }
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

        public static RECOMENDACAO SalvarRecomendacao(RECOMENDACAO recomendacaoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAO recomendacaoSalva = new RECOMENDACAO();

            try
            {

                if (recomendacaoDAO.IDREC > 0)
                {
                    recomendacaoSalva = contexto.RECOMENDACAO.First(x => x.IDREC == recomendacaoDAO.IDREC);

                    recomendacaoSalva.IDCGO = recomendacaoDAO.IDCGO;
                    recomendacaoSalva.IDCLI = recomendacaoDAO.IDCLI;
                    recomendacaoSalva.IDSETOR = recomendacaoDAO.IDSETOR;
                }
                else
                {
                    recomendacaoSalva = contexto.RECOMENDACAO.Add(recomendacaoDAO);
                }

                contexto.SaveChanges();
                return recomendacaoSalva;

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

        public static void AdicionarProcedimento(int codigoRecomendacao, int codigoProcedimento, int codigoReferente)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAOXASOXPRO procedimentoSalvo = null;
            RECOMENDACAOXASO recomendacaoReferente = recuperarRcomendacaoReferente(codigoRecomendacao, codigoReferente);

            try
            {

                if (!contexto.RECOMENDACAOXASOXPRO.Any(x => x.IDRECASO == recomendacaoReferente.IDRECASO && x.IDPRO == codigoProcedimento))
                {
                    procedimentoSalvo = new RECOMENDACAOXASOXPRO();

                    procedimentoSalvo.IDRECASO = recomendacaoReferente.IDRECASO;
                    procedimentoSalvo.IDPRO = codigoProcedimento;

                    contexto.RECOMENDACAOXASOXPRO.Add(procedimentoSalvo);
                    contexto.SaveChanges();
                }
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

        private static RECOMENDACAOXASO recuperarRcomendacaoReferente(int codigoRecomendacao, int codigoReferente)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAOXASO recomendacaoReferente = null;

            try
            {

                if (contexto.RECOMENDACAOXASO.Any(x => x.IDREC == codigoRecomendacao && x.IDREF == codigoReferente))
                {
                    recomendacaoReferente = contexto.RECOMENDACAOXASO.First(x => x.IDREC == codigoRecomendacao && x.IDREF == codigoReferente);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return recomendacaoReferente;
        }

        public static void AdicionarRisco(int codigoRecomendacao, int codigoRisco)
        {
            CloudMedContext contexto = new CloudMedContext();
            RECOMENDACAOXRISCO riscoSalvo = null;

            try
            {

                if (!contexto.RECOMENDACAOXRISCO.Any(x => x.IDREC == codigoRecomendacao && x.IDRISCO == codigoRisco))
                {
                    riscoSalvo = new RECOMENDACAOXRISCO();

                    riscoSalvo.IDRISCO = codigoRisco;
                    riscoSalvo.IDREC = codigoRecomendacao;

                    contexto.RECOMENDACAOXRISCO.Add(riscoSalvo);
                    contexto.SaveChanges();
                }
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
