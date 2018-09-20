namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RECOMENDACAOXASOXPRO")]
    public partial class RECOMENDACAOXASOXPRO
    {
        #region Public Properties

        [Column(TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDRECASO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRECPRO { get; set; }

        public int? PERIODICIDADE { get; set; }

        public virtual RECOMENDACAOXASO RECOMENDACAOXASO { get; set; }

        #endregion Public Properties
    }
}