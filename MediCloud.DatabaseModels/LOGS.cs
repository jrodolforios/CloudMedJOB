namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class LOGS
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLOG { get; set; }

        [Required]
        [StringLength(300)]
        public string OBSERVACAO { get; set; }

        [Required]
        [StringLength(50)]
        public string TIPO { get; set; }

        #endregion Public Properties
    }
}