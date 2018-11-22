namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_REPORTS
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_REPORTS()
        {
            SYS_KPI = new HashSet<SYS_KPI>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODREL { get; set; }

        [Column(TypeName = "text")]
        public string COMANDOSQL { get; set; }

        public DateTime? DATALT { get; set; }

        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] DIAGRAMA { get; set; }

        [StringLength(1)]
        public string EDITAVEL { get; set; }

        [Column(TypeName = "text")]
        public string ESTRUTURA { get; set; }

        [Column(TypeName = "text")]
        public string FILTROEXTERNO { get; set; }

        [Column(TypeName = "text")]
        public string HELP { get; set; }

        [StringLength(50)]
        public string ID_DEV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_KPI> SYS_KPI { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }

        #endregion Public Properties
    }
}