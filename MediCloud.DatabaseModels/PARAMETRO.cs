namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PARAMETRO")]
    public partial class PARAMETRO
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDPAR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDTAB { get; set; }

        [Required]
        [StringLength(50)]
        public string SENHATRANSFERIRMOV { get; set; }

        public virtual TABELA TABELA { get; set; }

        #endregion Public Properties
    }
}