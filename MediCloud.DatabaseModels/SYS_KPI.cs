namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_KPI
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODKPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODREL { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMEFORM { get; set; }

        [Column(TypeName = "text")]
        public string PARAMETROS { get; set; }

        public virtual SYS_REPORTS SYS_REPORTS { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO { get; set; }

        [Required]
        [StringLength(1)]
        public string USAFILTRO { get; set; }

        #endregion Public Properties
    }
}