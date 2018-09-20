namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NATUREZA")]
    public partial class NATUREZA
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDNAT { get; set; }

        [Column("NATUREZA")]
        [Required]
        [StringLength(50)]
        public string NATUREZA1 { get; set; }

        #endregion Public Properties
    }
}