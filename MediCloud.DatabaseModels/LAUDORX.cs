namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAUDORX")]
    public partial class LAUDORX
    {
        #region Public Properties

        [Required]
        [StringLength(500)]
        public string CONCLUSAO { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATA { get; set; }

        [Required]
        [StringLength(50)]
        public string IDADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDMODELO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDMOVPRO { get; set; }

        [Required]
        [StringLength(1000)]
        public string LAUDO { get; set; }

        [StringLength(500)]
        public string LAUDONEGRITO { get; set; }

        [Required]
        [StringLength(50)]
        public string MEDICO { get; set; }

        public virtual MODELOLAUDO MODELOLAUDO { get; set; }

        public virtual MOVIMENTO_PROCEDIMENTO MOVIMENTO_PROCEDIMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string PACIENTE { get; set; }

        [Required]
        [StringLength(500)]
        public string RODAPE { get; set; }

        [Required]
        [StringLength(50)]
        public string STATUS { get; set; }

        #endregion Public Properties
    }
}