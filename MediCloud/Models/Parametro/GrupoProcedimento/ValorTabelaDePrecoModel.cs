using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Parametro.GrupoProcedimento
{
    public class ValorTabelaDePrecoModel : IModel
    {
        public TabelaPrecoModel Tabela { get; set; }
        public FornecedorModel Fornecedor { get; set; }
        public ProcedimentoModel Procedimento { get; set; }
        public Decimal Valor { get; set; }

        public string toString()
        {
            return $"{Tabela.NomeTabela} - {Fornecedor.RazaoSocial} - {Procedimento.Nome}";
        }

        public int GetId()
        {
            string idString = Tabela.IdTabela.ToString() + Fornecedor.IdFornecedor.ToString() + Procedimento.IdProcedimento.ToString();

            return Convert.ToInt32(idString);
        }

        public void validar()
        {
            throw new NotImplementedException();
        }
    }
}