namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FATURAMENTO")]
    public partial class FATURAMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FATURAMENTO()
        {
            MOVIMENTO = new HashSet<MOVIMENTO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFAT { get; set; }

        [Required]
        [StringLength(3)]
        public string MES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ANO { get; set; }

        [StringLength(7)]
        public string USUARIO { get; set; }

        public DateTime DATA { get; set; }

        public decimal? VALOR { get; set; }

        [Required]
        [StringLength(2)]
        public string DIA { get; set; }

        public int IDCLI_INI { get; set; }

        public int IDCLI_FIN { get; set; }

        public DateTime? DATALIMITE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }
    }
}
