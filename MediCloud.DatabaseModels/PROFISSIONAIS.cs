namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PROFISSIONAIS
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFISSIONAIS()
        {
            MOVIMENTO_PROCEDIMENTO = new HashSet<MOVIMENTO_PROCEDIMENTO>();
            PROCEDIMENTO = new HashSet<PROCEDIMENTO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Key]
        [StringLength(4)]
        public string IDPRF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_PROCEDIMENTO> MOVIMENTO_PROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCEDIMENTO> PROCEDIMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string PROFISSIONAL { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        #endregion Public Properties
    }
}