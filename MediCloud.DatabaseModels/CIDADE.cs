namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CIDADE")]
    public partial class CIDADE
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIDADE()
        {
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            CLIENTE_GRUPO = new HashSet<CLIENTE_GRUPO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Column("CIDADE")]
        [Required]
        [StringLength(50)]
        public string CIDADE1 { get; set; }

        public int? CIDNF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_GRUPO> CLIENTE_GRUPO { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTADO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }

        #endregion Public Properties
    }
}