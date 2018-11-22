namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RECOMENDACAOXRISCO")]
    public partial class RECOMENDACAOXRISCO
    {
        #region Public Properties

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDREC { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRECXRISCO { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IDRISCO { get; set; }

        #endregion Public Properties
    }
}