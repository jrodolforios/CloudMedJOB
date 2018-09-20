namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_CONSULTA
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODCONSULTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODPRO { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] ESTRDIAGRAMA { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPODIAGR { get; set; }

        #endregion Public Properties
    }
}