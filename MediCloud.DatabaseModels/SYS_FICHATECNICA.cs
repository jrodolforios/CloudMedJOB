namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_FICHATECNICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_FICHATECNICA()
        {
            SYS_USRCOMPONENT = new HashSet<SYS_USRCOMPONENT>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMECATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMETELA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMETABELA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOMPONENT> SYS_USRCOMPONENT { get; set; }
    }
}
