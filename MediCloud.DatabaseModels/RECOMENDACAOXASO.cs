namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RECOMENDACAOXASO")]
    public partial class RECOMENDACAOXASO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECOMENDACAOXASO()
        {
            RECOMENDACAOXASOXPRO = new HashSet<RECOMENDACAOXASOXPRO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Column(TypeName = "numeric")]
        public decimal IDREC { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRECASO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDREF { get; set; }

        public virtual MOVIMENTO_REFERENTE MOVIMENTO_REFERENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECOMENDACAOXASOXPRO> RECOMENDACAOXASOXPRO { get; set; }

        #endregion Public Properties
    }
}