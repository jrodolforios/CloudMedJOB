namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTA_ORC_GRU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTA_ORC_GRU()
        {
            CONTA_ORC = new HashSet<CONTA_ORC>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDGRUCTA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMGRUCTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal NUMGRUCTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTA_ORC> CONTA_ORC { get; set; }
    }
}
