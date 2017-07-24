using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.BusinessProcess.Cliente.Reports;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeASO
    {
        public static List<MOVIMENTO> buscarASO(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.MOVIMENTO.ToList();
                }
                else
                {
                    return contexto.MOVIMENTO.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                        || x.FUNCIONARIO.FUNCIONARIO1.Contains(termo)
                        || ((int)x.IDMOV).ToString() == termo).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ContagemASOsNoMes()
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO.Count(x => x.DATAMOV.HasValue ? (x.DATAMOV.Value.Month == DateTime.Now.Month && x.DATAMOV.Value.Year == DateTime.Now.Year) : false);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ContagemDeASOsNaoFaturados()
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO.Count(x => x.IDFCX == null || x.IDFCX <= 0);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MOVIMENTO buscarASOPorId(int idASO)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (idASO <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.MOVIMENTO.First(x => x.IDMOV == idASO);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new MOVIMENTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MOVIMENTO SalvarASO(MOVIMENTO ASODAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO usuarioSalvo = new MOVIMENTO();

            try
            {

                if (ASODAO.IDMOV > 0)
                {
                    usuarioSalvo = contexto.MOVIMENTO.First(x => x.IDMOV == ASODAO.IDMOV);

                    usuarioSalvo.CAIXAPENDENTE = ASODAO.CAIXAPENDENTE;
                    usuarioSalvo.DATA = ASODAO.DATA;
                    usuarioSalvo.DATAMOV = ASODAO.DATAMOV;
                    usuarioSalvo.FATURA = ASODAO.FATURA;
                    usuarioSalvo.IDCGO = ASODAO.IDCGO;
                    usuarioSalvo.IDCLI = ASODAO.IDCLI;
                    usuarioSalvo.IDFAT = ASODAO.IDFAT;
                    usuarioSalvo.IDFCX = ASODAO.IDFCX;
                    usuarioSalvo.IDFORPAG = ASODAO.IDFORPAG;
                    usuarioSalvo.IDFUN = ASODAO.IDFUN;
                    usuarioSalvo.IDMOV = ASODAO.IDMOV;
                    usuarioSalvo.IDREF = ASODAO.IDREF;
                    usuarioSalvo.IDSETOR = ASODAO.IDSETOR;
                    usuarioSalvo.IDTAB = ASODAO.IDTAB;
                    usuarioSalvo.OBSERVACAO = ASODAO.OBSERVACAO;
                    usuarioSalvo.STATUS = ASODAO.STATUS;
                    usuarioSalvo.TIPO = ASODAO.TIPO;
                    usuarioSalvo.USUARIO = ASODAO.USUARIO;

                }
                else
                {
                    //ASOs novos tem seu caixa sempre pendente
                    ASODAO.CAIXAPENDENTE = true;

                    usuarioSalvo = contexto.MOVIMENTO.Add(ASODAO);
                }

                contexto.SaveChanges();
                return usuarioSalvo;

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

        public static void MarcarASOComoEntregue(int codigoASO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO ASOASerEntregue = null;
            try
            {
                if (contexto.MOVIMENTO.Any(x => x.IDMOV == codigoASO))
                {
                    ASOASerEntregue = contexto.MOVIMENTO.First(x => x.IDMOV == codigoASO);

                    ASOASerEntregue.STATUS = !string.IsNullOrEmpty(ASOASerEntregue.STATUS) ? (ASOASerEntregue.STATUS == "ENTREGUE" ? "PENDENTE" : "ENTREGUE") : "ENTREGUE";
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

        public static List<MOVIMENTO_ARQUIVOS> CarregarArquivosSemBinarios(decimal iDMOV)
        {
            CloudMedContext contexto = new CloudMedContext();
            List<MOVIMENTO_ARQUIVOS> listaBancoSemBinarios = new List<MOVIMENTO_ARQUIVOS>();

            try
            {
                var lista = contexto.MOVIMENTO_ARQUIVOS.Where(x => x.IDMOV == iDMOV);

                foreach (var item in lista)
                {
                    listaBancoSemBinarios.Add(new MOVIMENTO_ARQUIVOS()
                    {
                        DATAENVIO = item.DATAENVIO,
                        IDARQUIVO = item.IDARQUIVO,
                        IDMOV = item.IDMOV,
                        MOVIMENTO = item.MOVIMENTO,
                        NOMEARQUIVO = item.NOMEARQUIVO,
                        ARQUIVO = null
                    });
                }

                return listaBancoSemBinarios;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO_ARQUIVOS>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SalvarArquivo(byte[] fileData, string fileName, int codigoASO)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                MOVIMENTO_ARQUIVOS arquivo = new MOVIMENTO_ARQUIVOS()
                {
                    ARQUIVO = fileData,
                    DATAENVIO = DateTime.Now,
                    IDARQUIVO = 0,
                    IDMOV = codigoASO,
                    NOMEARQUIVO = fileName
                };

                contexto.MOVIMENTO_ARQUIVOS.Add(arquivo);

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

        public static MOVIMENTO_ARQUIVOS recuperarBinarioDeArquivo(int codigoArquivo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.MOVIMENTO_ARQUIVOS.Any(x => x.IDARQUIVO == codigoArquivo))
                    return contexto.MOVIMENTO_ARQUIVOS.First(x => x.IDARQUIVO == codigoArquivo);
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

        public static void DeletarArquivo(int codigoArquivo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.MOVIMENTO_ARQUIVOS.Any(x => x.IDARQUIVO == codigoArquivo))
                    contexto.MOVIMENTO_ARQUIVOS.Remove(contexto.MOVIMENTO_ARQUIVOS.First(x => x.IDARQUIVO == codigoArquivo));

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

        public static byte[] ImprimirASOComMedCoord(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(infoClinica, aso, recuperarNaturezaERiscosDeASO(aso), Util.Enum.Cliente.ASOReportEnum.imprimirComMedCoord);

            return Report.generate();
        }

        public static Dictionary<NATUREZA, List<RISCO>> recuperarNaturezaERiscosDeASO(MOVIMENTO mov)
        {
            Dictionary<NATUREZA, List<RISCO>> naturezasERiscos = new Dictionary<NATUREZA, List<RISCO>>();
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                List<RECOMENDACAO> recomendacao = contexto.RECOMENDACAO.Where(x => x.IDCLI == mov.IDCLI && x.IDCGO == mov.IDCGO && x.IDSETOR == mov.IDSETOR).ToList();

                List<RECOMENDACAOXRISCO> recomendacaoRisco = new List<RECOMENDACAOXRISCO>();
                recomendacao.ForEach(x =>
                {
                    recomendacaoRisco.AddRange(contexto.RECOMENDACAOXRISCO.Where(y => y.IDREC == x.IDREC));
                });

                List<RISCO> riscos = new List<RISCO>();
                recomendacaoRisco.ForEach(x =>
                {
                    riscos.AddRange(contexto.RISCO.Where(y => y.IDRISCO == x.IDRISCO));
                });

                List<NATUREZA> naturezas = new List<NATUREZA>();
                riscos.ForEach(x =>
                {
                    naturezas.AddRange(contexto.NATUREZA.Where(y => y.IDNAT == x.IDNAT));
                });

                naturezas.ForEach(x =>
                {
                    if (!naturezasERiscos.Keys.Any(y => y == x))
                        naturezasERiscos.Add(x, riscos.Where(y => y.IDNAT == x.IDNAT).ToList());
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

            return naturezasERiscos;
        }

        public static void ConfirmarASO(string login, int codigoDoMovimento)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO usuarioSalvo = new MOVIMENTO();

            try
            {

                if (codigoDoMovimento > 0)
                {
                    usuarioSalvo = contexto.MOVIMENTO.First(x => x.IDMOV == codigoDoMovimento);

                    usuarioSalvo.MOVIMENTO_PROCEDIMENTO.ToList().ForEach(x =>
                    {
                        ControleDeProcedimentosMovimento.ConfirmarExame(login, (int)x.IDMOVPRO);
                    });
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

        public static byte[] ImprimirOrdemDeServico(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(aso, Util.Enum.Cliente.ASOReportEnum.imprimirOrdemServicoASO, infoClinica);

            return Report.generate();
        }

        public static byte[] ImprimirFichaClinica(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(aso, Util.Enum.Cliente.ASOReportEnum.imprimirFichaClinica, infoClinica);

            return Report.generate();
        }

        public static byte[] ImprimirListaDeProcedimentos(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(aso, Util.Enum.Cliente.ASOReportEnum.imprimirListaDeProcedimentos, infoClinica);

            return Report.generate();
        }

        public static byte[] ImprimirASOSemMedCoord(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(infoClinica, aso, recuperarNaturezaERiscosDeASO(aso), Util.Enum.Cliente.ASOReportEnum.imprimirSemMedCoord);

            return Report.generate();
        }

        public static byte[] ImprimirReciboASO(int codigoASO)
        {
            MOVIMENTO aso = ControleDeASO.buscarASOPorId(codigoASO);
            INFORMACOES_CLINICA infoClinica = Util.Util.RecuperarInformacoesDaClinica();

            ASOReports Report = new ASOReports(infoClinica, aso, recuperarNaturezaERiscosDeASO(aso), Util.Enum.Cliente.ASOReportEnum.imprimirReciboASO);

            return Report.generate();
        }

        public static decimal CalcularValorTotalDeASO(MOVIMENTO MOV)
        {
            decimal soma = 0;

            MOV.MOVIMENTO_PROCEDIMENTO.ToList().ForEach(x =>
            {
                soma += x.TOTAL.HasValue ? x.TOTAL.Value : 0;
            });

            return soma;
        }
    }
}
