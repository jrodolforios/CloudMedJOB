namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_REPORTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_REPORTS()
        {
            SYS_KPI = new HashSet<SYS_KPI>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODREL { get; set; }

        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [StringLength(50)]
        public string ID_DEV { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }

        [Column(TypeName = "text")]
        public string COMANDOSQL { get; set; }

        [Column(TypeName = "image")]
        public byte[] DIAGRAMA { get; set; }

        [Column(TypeName = "text")]
        public string FILTROEXTERNO { get; set; }

        [Column(TypeName = "text")]
        public string HELP { get; set; }

        [Column(TypeName = "text")]
        public string ESTRUTURA { get; set; }

        public DateTime? DATALT { get; set; }

        [StringLength(1)]
        public string EDITAVEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_KPI> SYS_KPI { get; set; }
    }
}
