namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROCEDIMENTO_GRUPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROCEDIMENTO_GRUPO()
        {
            PROCEDIMENTO_GRUPO_SUBGRUP = new HashSet<PROCEDIMENTO_GRUPO_SUBGRUP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDGRUPRO { get; set; }

        [Required]
        [StringLength(50)]
        public string GRUPOPROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCEDIMENTO_GRUPO_SUBGRUP> PROCEDIMENTO_GRUPO_SUBGRUP { get; set; }
    }
}
