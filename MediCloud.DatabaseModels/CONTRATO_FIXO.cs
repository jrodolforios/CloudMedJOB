namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTRATO_FIXO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTRATO_FIXO()
        {
            CONTRATO_FIXO_DET = new HashSet<CONTRATO_FIXO_DET>();
        }

        [StringLength(50)]
        public string USUARIO { get; set; }

        public int? QUANTIDADE { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATA { get; set; }

        [Required]
        [StringLength(50)]
        public string DIA { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLAN { get; set; }

        [Required]
        [StringLength(50)]
        public string SITUACAO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFOR { get; set; }

        public decimal? TOTAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO_FIXO_DET> CONTRATO_FIXO_DET { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }
    }
}
