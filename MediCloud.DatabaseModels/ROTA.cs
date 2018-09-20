namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ROTA")]
    public partial class ROTA
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROTA()
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
        public decimal IDROTA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMEROTA { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACAO { get; set; }

        #endregion Public Properties
    }
}