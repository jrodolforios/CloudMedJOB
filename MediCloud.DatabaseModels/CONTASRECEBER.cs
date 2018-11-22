namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CONTASRECEBER")]
    public partial class CONTASRECEBER
    {
        #region Public Properties

        [StringLength(6)]
        public string AGENCIABANCOEMI { get; set; }

        public int? BANCO { get; set; }

        public int? BANCO_ID { get; set; }

        public int? CAIXA { get; set; }

        [StringLength(14)]
        public string CGC_CPF { get; set; }

        public int? CLIENTE { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        public int? CODIGOCENTROCUSTO { get; set; }

        [StringLength(7)]
        public string CODIGOCONTAORC { get; set; }

        public int? CODIGOPASTA { get; set; }

        public int? CODIGOTIPODOCTO { get; set; }

        public DateTime? DATABOLETO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public DateTime? DATAEMISSAO { get; set; }

        public DateTime? DATAPAGAMENTO { get; set; }

        public DateTime? DATAVENCIMENTO { get; set; }

        [StringLength(15)]
        public string DOCUMENTO { get; set; }

        [StringLength(15)]
        public string DOCUMENTOBAIXA { get; set; }

        public DateTime? DT_COMPETENCIA { get; set; }

        [StringLength(255)]
        public string HISTORICO { get; set; }

        [StringLength(45)]
        public string NOMEBANCOEMI { get; set; }

        [StringLength(60)]
        public string NOMEEMI { get; set; }

        [StringLength(15)]
        public string NOSSONUMERO { get; set; }

        [StringLength(6)]
        public string NROBANCOEMI { get; set; }

        [StringLength(10)]
        public string NROCHEQUEEMI { get; set; }

        [StringLength(15)]
        public string NROCONTAEMI { get; set; }

        [StringLength(10)]
        public string ORIGEM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORDESCONTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORJUROS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORMULTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORPAGAMENTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORVENCIMENTO { get; set; }

        #endregion Public Properties
    }
}