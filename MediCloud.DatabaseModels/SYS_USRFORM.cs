namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRFORM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_USRFORM()
        {
            SYS_USRCOMPONENT = new HashSet<SYS_USRCOMPONENT>();
            SYS_USRFORMXTABLE = new HashSet<SYS_USRFORMXTABLE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODFORM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSRTABLE { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(1)]
        public string FORMPADRAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] ICONE { get; set; }

        [Required]
        [StringLength(150)]
        public string NOME { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPOFORM { get; set; }

        [Required]
        [StringLength(300)]
        public string TITULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOMPONENT> SYS_USRCOMPONENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRFORMXTABLE> SYS_USRFORMXTABLE { get; set; }

        public virtual SYS_USRTABLE SYS_USRTABLE { get; set; }
    }
}
