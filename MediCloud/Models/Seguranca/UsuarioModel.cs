using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Seguranca
{
    public class UsuarioModel :IModel
    {
        public UsuarioModel()
        {

        }

        public int Codigo { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public bool AcessoBloqueado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataParaBloqueio { get; set; }
        public string SenhaCriptografada { get; set; }
        public string SenhaDescriptografada { get; set; }
        public string RepetirSenhaDescriptografada { get; set; }

        public string toString()
        {
            return $"{NomeUsuario} | {LoginUsuario}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeUsuario))
                erros.Add("O campo \"Nome Completo\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(LoginUsuario))
                erros.Add("O campo \"Login\" é de preenchimento obrigatório");

            if (Codigo == 0)
            {
                if (string.IsNullOrEmpty(SenhaDescriptografada) || string.IsNullOrEmpty(RepetirSenhaDescriptografada))
                    erros.Add("Os campos \"Senha\" e \"Repita a senha\" deve ser devidamente preenchidos");
            }


            if (!string.IsNullOrEmpty(SenhaDescriptografada + RepetirSenhaDescriptografada) && SenhaDescriptografada != RepetirSenhaDescriptografada)
                erros.Add("Os campos \"Senha\" e \"Repita a senha\" devem ser idênticos");

            if (erros.Any())
            {
                errosTratados = tratarListaDeErros(erros);

                throw new InvalidOperationException(errosTratados);
            }
        }

        private string tratarListaDeErros(List<string> erros)
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("Verifique os seguintes itens antes de salvar:");

            erros.ForEach(x =>
            {
                strBuilder.AppendLine("- " + x);
            });

            return strBuilder.ToString();
        }
    }
}