namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_CONTRATOFIXO
    {
        #region Public Properties

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual CLIENTE_CREDIARIO CLIENTE_CREDIARIO { get; set; }

        public bool? COBRARASO { get; set; }

        public decimal? DESCONTO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string DESCRICAO { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool HABILITADO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDTAB { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        public virtual TABELA TABELA { get; set; }

        public virtual TABELAXFORNECEDORXPROCEDIMENTO TABELAXFORNECEDORXPROCEDIMENTO { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime VALIDADE { get; set; }

        [Key]
        [Column(Order = 0)]
        public decimal VALOR { get; set; }

        #endregion Public Properties
    }
}