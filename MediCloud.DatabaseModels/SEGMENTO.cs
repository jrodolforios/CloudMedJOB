namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SEGMENTO")]
    public partial class SEGMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEGMENTO()
        {
            CLIENTE = new HashSet<CLIENTE>();
            CLIENTE_GRUPO = new HashSet<CLIENTE_GRUPO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_GRUPO> CLIENTE_GRUPO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDSEG { get; set; }

        [Column("SEGMENTO")]
        [Required]
        [StringLength(50)]
        public string SEGMENTO1 { get; set; }

        #endregion Public Properties
    }
}