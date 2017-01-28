namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_USRTABLE()
        {
            SYS_USRCOLUMN = new HashSet<SYS_USRCOLUMN>();
            SYS_USRFORM = new HashSet<SYS_USRFORM>();
            SYS_USRFORMXTABLE = new HashSet<SYS_USRFORMXTABLE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODUSRTABLE { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(150)]
        public string DESCRICAO { get; set; }

        [Required]
        [StringLength(150)]
        public string NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOLUMN> SYS_USRCOLUMN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRFORM> SYS_USRFORM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRFORMXTABLE> SYS_USRFORMXTABLE { get; set; }
    }
}
