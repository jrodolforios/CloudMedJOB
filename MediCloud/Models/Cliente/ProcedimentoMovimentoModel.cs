using MediCloud.Models.Financeiro;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Cliente
{
    public class ProcedimentoMovimentoModel : IModel
    {
        public int IdMovimentoProcedimento { get; set; }

        public decimal? Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Total { get; set; }

        public string Usuario { get; set; }
        public string UsuarioRealizado { get; set; }

        public ASOModel Movimento { get; set; }
        public string observacao { get; set; }
        public DateTime? DataRealizado { get; set; }
        public int? IdFechamentoCaixa { get; set; }
        public FaturamentoModel Faturamento { get; set; }
        public DateTime? DataExame { get; set; }

        public FornecedorModel Fornecedor { get; set; }
        public ProfissionalModel Profissional { get; set; }
        public ProcedimentoModel Procedimento { get; set; }

        public string toString()
        {
            if (Procedimento != null && Movimento != null && Movimento.Funcionario != null && Movimento.Cliente != null)
                return $"{Procedimento.Nome} - {Movimento.Funcionario.NomeCompleto} ({Movimento.Cliente.RazaoSocial})";
            else
                return base.ToString();
        }

        public void validar()
        {
            //Todos os campos são opcionais.
        }
    }
}