namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FECHAMENTO_CAIXA
    {
        #region Public Properties

        public DateTime DATA { get; set; }

        public DateTime? DATA_FECHAMENTO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFCX { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACOES { get; set; }

        [Required]
        [StringLength(1)]
        public string PERIODO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QUANTIDADE { get; set; }

        public decimal? TOTAL { get; set; }

        [StringLength(20)]
        public string USUARIO { get; set; }

        #endregion Public Properties
    }
}