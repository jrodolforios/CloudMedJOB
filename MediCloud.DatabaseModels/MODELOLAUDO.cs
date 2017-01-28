namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MODELOLAUDO")]
    public partial class MODELOLAUDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODELOLAUDO()
        {
            LAUDORX = new HashSet<LAUDORX>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDMODELO { get; set; }

        [Required]
        [StringLength(50)]
        public string MODELO { get; set; }

        [Required]
        [StringLength(1000)]
        public string LAUDO { get; set; }

        [Required]
        [StringLength(500)]
        public string CONCLUSAO { get; set; }

        [Required]
        [StringLength(500)]
        public string RODAPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAUDORX> LAUDORX { get; set; }
    }
}
