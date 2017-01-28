namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRCOMPONENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_USRCOMPONENT()
        {
            SYS_FICHATECNICA = new HashSet<SYS_FICHATECNICA>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODCOMPONENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODFORM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODUSRCOLUMN { get; set; }

        [Column(TypeName = "text")]
        public string CONFCOMPONENT { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(300)]
        public string DATAOBJECT { get; set; }

        [StringLength(150)]
        public string DESCRICAO { get; set; }

        [StringLength(150)]
        public string NOME { get; set; }

        [Required]
        [StringLength(300)]
        public string PARENT { get; set; }

        [Required]
        [StringLength(300)]
        public string TIPO { get; set; }

        public virtual SYS_USRCOLUMN SYS_USRCOLUMN { get; set; }

        public virtual SYS_USRFORM SYS_USRFORM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_FICHATECNICA> SYS_FICHATECNICA { get; set; }
    }
}
