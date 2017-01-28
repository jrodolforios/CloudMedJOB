namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CENTROCUSTO")]
    public partial class CENTROCUSTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CENTROCUSTO()
        {
            LCTOSCAIXA = new HashSet<LCTOSCAIXA>();
        }

        [StringLength(10)]
        public string APELIDO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CEN_ID { get; set; }

        public DateTime? DATACAD { get; set; }

        [StringLength(45)]
        public string NOME { get; set; }

        [StringLength(255)]
        public string NOTAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCTOSCAIXA> LCTOSCAIXA { get; set; }
    }
}
