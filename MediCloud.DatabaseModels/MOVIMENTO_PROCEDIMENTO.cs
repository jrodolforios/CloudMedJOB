namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOVIMENTO_PROCEDIMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIMENTO_PROCEDIMENTO()
        {
            LAUDOAUD = new HashSet<LAUDOAUD>();
        }

        public decimal? VALOR { get; set; }

        public decimal? DESCONTO { get; set; }

        [StringLength(20)]
        public string USUARIO { get; set; }

        [StringLength(4)]
        public string IDPRF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDMOV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDPRO { get; set; }

        [StringLength(50)]
        public string OBSMOVTO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDMOVPRO { get; set; }

        public decimal? TOTAL { get; set; }

        public DateTime? DATAREALIZADO { get; set; }

        [StringLength(20)]
        public string USUARIOREALIZADO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFCX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        [StringLength(200)]
        public string OBSREALIZADO { get; set; }

        public DateTime? PROXEXAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATAEXAME { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAUDOAUD> LAUDOAUD { get; set; }

        public virtual LAUDORX LAUDORX { get; set; }

        public virtual MOVIMENTO MOVIMENTO { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        public virtual PROFISSIONAIS PROFISSIONAIS { get; set; }
    }
}
