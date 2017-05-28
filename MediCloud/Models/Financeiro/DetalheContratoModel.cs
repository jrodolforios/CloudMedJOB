using MediCloud.Models.Cliente;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class DetalheContratoModel : IModel
    {
        public int IdDetalheContrato { get; set; }

        public ASOModel ASO { get; set; }
        public decimal Valor { get; set; }
        public LancamentoDeContratoModel Contrato { get; set; }
        public ProcedimentoModel Procedimento { get; set; }
        public ClienteModel Cliente { get; set; }
        public TabelaPrecoModel Tabela { get; set; }

        public string toString()
        {
            return ASO?.Cliente?.NomeFantasia;
        }

        public void validar()
        {
            //Vazio
        }
    }
}