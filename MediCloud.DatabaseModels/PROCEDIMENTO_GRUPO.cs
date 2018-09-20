namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PROCEDIMENTO_GRUPO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROCEDIMENTO_GRUPO()
        {
            PROCEDIMENTO_GRUPO_SUBGRUP = new HashSet<PROCEDIMENTO_GRUPO_SUBGRUP>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Required]
        [StringLength(50)]
        public string GRUPOPROCEDIMENTO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDGRUPRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCEDIMENTO_GRUPO_SUBGRUP> PROCEDIMENTO_GRUPO_SUBGRUP { get; set; }

        #endregion Public Properties
    }
}