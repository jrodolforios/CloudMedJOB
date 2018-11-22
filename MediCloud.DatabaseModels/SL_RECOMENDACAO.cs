namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SL_RECOMENDACAO
    {
        #region Public Properties

        [Key]
        [Column(Order = 13)]
        [StringLength(6)]
        public string ABREVIADO { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string CARGO { get; set; }

        [StringLength(50)]
        public string COMPLEMENTO { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(50)]
        public string GRUPOPROCEDIMENTO { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal IDCGO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFOR { get; set; }

        [Key]
        [Column(Order = 16, TypeName = "numeric")]
        public decimal IDGRUPRO { get; set; }

        [StringLength(4)]
        public string IDPRF { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDREC { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal IDRECASO { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "numeric")]
        public decimal IDRECPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDREF { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal IDSETOR { get; set; }

        [Key]
        [Column(Order = 14, TypeName = "numeric")]
        public decimal IDSUBGRUPRO { get; set; }

        [StringLength(50)]
        public string NFFOR { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string NOMEREFERENCIA { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(30)]
        public string PROCEDIMENTO { get; set; }

        [StringLength(50)]
        public string PROFISSIONAL { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        [StringLength(50)]
        public string RSFOR { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string SETOR { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(30)]
        public string SUBGRUPO { get; set; }

        #endregion Public Properties
    }
}