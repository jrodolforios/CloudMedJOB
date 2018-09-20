namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CONTA_ORC
    {
        #region Public Properties

        public virtual CONTA_ORC_GRU CONTA_ORC_GRU { get; set; }

        [Required]
        [StringLength(1)]
        public string DEBCRE { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDGRUCTA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMECONTAORC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal NUMCTAORC { get; set; }

        #endregion Public Properties
    }
}