namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNCIONARIO")]
    public partial class FUNCIONARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNCIONARIO()
        {
            LAUDOAV = new HashSet<LAUDOAV>();
            MOVIMENTO = new HashSet<MOVIMENTO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFUN { get; set; }

        [Column("FUNCIONARIO")]
        [Required]
        [StringLength(50)]
        public string FUNCIONARIO1 { get; set; }

        [StringLength(15)]
        public string RG { get; set; }

        [StringLength(20)]
        public string CTPS { get; set; }

        [StringLength(50)]
        public string MATRICULA { get; set; }

        [StringLength(10)]
        public string CODNEXO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        public DateTime? NASCIMENTO { get; set; }

        public DateTime? DATAULTIMOMOV { get; set; }

        public bool? INATIVO { get; set; }

        public int? ULTIMOIDMOV { get; set; }

        [StringLength(200)]
        public string ENDERECO { get; set; }

        [Required]
        [StringLength(50)]
        public string CELULAR { get; set; }

        [Required]
        [StringLength(50)]
        public string TELEFONE { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAUDOAV> LAUDOAV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }
    }
}
