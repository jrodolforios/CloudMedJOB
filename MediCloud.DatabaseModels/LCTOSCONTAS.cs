namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class LCTOSCONTAS
    {
        #region Public Properties

        [StringLength(6)]
        public string AGENCIABANCOEMI { get; set; }

        [StringLength(14)]
        public string CGC_CPF_EMI { get; set; }

        public int? CODIGOCENTROCUSTO { get; set; }

        [StringLength(7)]
        public string CODIGOCONTAORC { get; set; }

        [StringLength(7)]
        public string CODIGOCONTAORCDEST { get; set; }

        public int? CODIGOPASTAMOV { get; set; }

        public int? CODIGOPASTAMOVDEST { get; set; }

        public int? CONTADESTINO { get; set; }

        public int? CONTATRANSFERENCIA { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CONTROLE { get; set; }

        public int? CONTROLEORIGEMTRANSF { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        public DateTime? DATAEMISSAO { get; set; }

        public DateTime? DATAENTRADA { get; set; }

        [StringLength(15)]
        public string DOCUMENTO { get; set; }

        public DateTime? DT_COMPETENCIA { get; set; }

        [StringLength(1)]
        public string EFETUADO { get; set; }

        [StringLength(255)]
        public string HISTORICO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IMPOSTO { get; set; }

        [StringLength(40)]
        public string NOMEBANCOEMI { get; set; }

        [StringLength(45)]
        public string NOMEEMI { get; set; }

        [StringLength(6)]
        public string NROBANCOEMI { get; set; }

        [StringLength(15)]
        public string NROCHEQUE { get; set; }

        [StringLength(15)]
        public string NROCHEQUEEMI { get; set; }

        [StringLength(15)]
        public string NROCONTAEMI { get; set; }

        [StringLength(1)]
        public string OPERACAO { get; set; }

        [StringLength(10)]
        public string ORIGEM { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALOR { get; set; }

        #endregion Public Properties
    }
}