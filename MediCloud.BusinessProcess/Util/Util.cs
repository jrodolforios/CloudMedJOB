using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Script.Serialization;

namespace MediCloud.BusinessProcess.Util
{
    public class Util
    {
        #region Public Methods

        public static string ApenasNumeros(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
                return new string(valor.Where(c => char.IsDigit(c)).ToArray());
            else
                return null;
        }

        public static int CalcularIdade(DateTime? nascimento)
        {
            if (nascimento.HasValue)
            {
                // Save today's date.
                var today = DateTime.UtcNow;
                // Calculate the age.
                var age = today.Year - nascimento.Value.Year;
                // Do stuff with it.
                if (nascimento > today.AddYears(-age)) age--;

                return age;
            }
            else
                return -1;
        }

        public static string dataToExtenso(DateTime dateTime)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = dateTime.Day;
            int ano = dateTime.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dateTime.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(dateTime.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;

            return data;
        }

        public static void EnviarEmail(string destinatarios, string assunto, string corpo)
        {
            string remetente = ConfigurationManager.AppSettings["RemetenteEmail"].ToString();
            int porta = Convert.ToInt32(ConfigurationManager.AppSettings["PortaEmail"].ToString());
            string hostSMTP = ConfigurationManager.AppSettings["HostSMTPEmail"].ToString();

            string nomeUsuario = ConfigurationManager.AppSettings["NomeUsuarioEmail"].ToString();
            string senhaUsuario = ConfigurationManager.AppSettings["SenhaUsuarioEmail"].ToString();
            bool habilitarSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitarSSLEmail"].ToString());

            MailMessage mail = new MailMessage(remetente, destinatarios);

            SmtpClient client = new SmtpClient();
            client.Port = porta;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = hostSMTP;
            client.ServicePoint.MaxIdleTime = 1;

            client.Credentials = new NetworkCredential(nomeUsuario, senhaUsuario);
            client.EnableSsl = habilitarSSL;

            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body = corpo;
            client.Send(mail);
        }

        // O método toExtenso recebe um valor do tipo decimal
        public static string toExtenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;

                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);

                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";

                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " REAL";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " REAIS";

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " E ";
                    }

                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " CENTAVO";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " CENTAVOS";
                }
                return valor_por_extenso;
            }
        }

        public static List<string> TrocarVirgulaPorPonto(List<decimal?> list)
        {
            List<string> listaDeNumerosEmString = new List<string>();

            list.ForEach(x =>
            {
                listaDeNumerosEmString.Add(x.ToString().Replace(',', '.'));
            });

            return listaDeNumerosEmString;
        }

        #endregion Public Methods

        #region Internal Methods

        internal static void EnviarEmailDeErro(LOG_ERRO logPersistido)
        {
            StringBuilder str = new StringBuilder();
            string informacaoDaClinica = RecuperarInformacoesDaClinica().DADOSCABECALHOREL;
            string json = new JavaScriptSerializer().Serialize(logPersistido);
            string destinatario = ConfigurationManager.AppSettings["RemetenteEmail"].ToString();

            str.Append(informacaoDaClinica);
            str.Append("<br/><br/>");

            str.Append(json);

            EnviarEmail(destinatario, "[Log_Erro] Exceção lançada no CloudMed", str.ToString());
        }

        internal static string InserirMascaraCNPJ(string CNPJ)
        {
            ulong CNPJTratado = Convert.ToUInt64(ApenasNumeros(CNPJ));
            return CNPJTratado.ToString(@"00\.000\.000\/0000\-00");
        }

        internal static string InserirMascaraCPF(string CPF)
        {
            ulong CPFTratado = Convert.ToUInt64(ApenasNumeros(CPF));
            return CPFTratado.ToString(@"000\.000\.000\-00");
        }

        internal static INFORMACOES_CLINICA RecuperarInformacoesDaClinica()
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.INFORMACOES_CLINICA.Any())
                    return contexto.INFORMACOES_CLINICA.First();
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

        #endregion Internal Methods



        #region Private Methods

        private static string escreva_parte(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

        #endregion Private Methods
    }
}