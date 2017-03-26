using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Fornecedor
{
    public class ContatoModel : IModel
    {
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelfoneMovel { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }


        public string toString()
        {
            return $"{NomeContato} - {Funcao}";
        }

        public void validar()
        {
            // void
        }
    }
}