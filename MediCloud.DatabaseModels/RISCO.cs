namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RISCO")]
    public partial class RISCO
    {
        #region Public Properties

        [Required]
        [StringLength(50)]
        public string EVENTUALIDADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDNAT { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRISCO { get; set; }

        public virtual NATUREZA NATUREZA { get; set; }

        [Column("RISCO")]
        [Required]
        [StringLength(50)]
        public string RISCO1 { get; set; }

        #endregion Public Properties
    }
}