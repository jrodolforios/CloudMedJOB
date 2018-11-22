namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LCTOSCAIXA")]
    public partial class LCTOSCAIXA
    {
        #region Public Properties

        public virtual CENTROCUSTO CENTROCUSTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODIGOCENTROCUSTO { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODIGOCOMPCX { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string CODIGOCONTAORC { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CODIGOPASTAMOV { get; set; }

        public virtual COMPOSICOESCAIXA COMPOSICOESCAIXA { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal CONTROLE { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime DATA { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(15)]
        public string DOCUMENTO { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime DT_COMPETENCIA { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(255)]
        public string HISTORICO { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string OPERACAO { get; set; }

        [StringLength(10)]
        public string ORIGEM { get; set; }

        public virtual PASTASMOV PASTASMOV { get; set; }

        public virtual PASTASMOV PASTASMOV1 { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal VALOR { get; set; }

        #endregion Public Properties
    }
}