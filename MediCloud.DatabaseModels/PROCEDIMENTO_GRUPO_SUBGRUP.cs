namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PROCEDIMENTO_GRUPO_SUBGRUP
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROCEDIMENTO_GRUPO_SUBGRUP()
        {
            PROCEDIMENTO = new HashSet<PROCEDIMENTO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Column(TypeName = "numeric")]
        public decimal? IDGRUPRO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDSUBGRUPRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCEDIMENTO> PROCEDIMENTO { get; set; }

        public virtual PROCEDIMENTO_GRUPO PROCEDIMENTO_GRUPO { get; set; }

        [Required]
        [StringLength(30)]
        public string SUBGRUPO { get; set; }

        #endregion Public Properties
    }
}