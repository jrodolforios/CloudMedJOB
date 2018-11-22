namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLCONSULTAMOVIMENTO")]
    public partial class SLCONSULTAMOVIMENTO
    {
        #region Public Properties

        [Key]
        [Column(Order = 15)]
        [StringLength(3)]
        public string CAIXAPENDENTE { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string CARGO { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(3)]
        public string CONFIRMADO { get; set; }

        [StringLength(50)]
        public string DATA { get; set; }

        [StringLength(50)]
        public string DATAEXAME { get; set; }

        [StringLength(50)]
        public string DATAMOV { get; set; }

        [StringLength(50)]
        public string DATAREALIZADO { get; set; }

        public decimal? DESCONTO { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(3)]
        public string FATURADO { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string FUNCIONARIO { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFCX { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IDFUN { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDMOV { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDMOVPRO { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string NOMECLI { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [StringLength(50)]
        public string NOMEREFERENCIA { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(30)]
        public string PROCEDIMENTO { get; set; }

        [StringLength(50)]
        public string PROFISSIONAL { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string RAZAOCLI { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(30)]
        public string SUBGRUPO { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(30)]
        public string TABELA { get; set; }

        [StringLength(1)]
        public string TIPOPAGTO { get; set; }

        public decimal? TOTAL { get; set; }

        [StringLength(10)]
        public string USUARIO { get; set; }

        [StringLength(10)]
        public string USUARIOREALIZADO { get; set; }

        public decimal? VALOR { get; set; }

        #endregion Public Properties
    }
}