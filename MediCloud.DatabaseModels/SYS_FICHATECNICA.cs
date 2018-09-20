namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_FICHATECNICA
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_FICHATECNICA()
        {
            SYS_USRCOMPONENT = new HashSet<SYS_USRCOMPONENT>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMECATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMETABELA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMETELA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOMPONENT> SYS_USRCOMPONENT { get; set; }

        #endregion Public Properties
    }
}