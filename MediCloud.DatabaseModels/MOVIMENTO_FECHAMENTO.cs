namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class MOVIMENTO_FECHAMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIMENTO_FECHAMENTO()
        {
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            CLIENTE_GRUPO = new HashSet<CLIENTE_GRUPO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_GRUPO> CLIENTE_GRUPO { get; set; }

        [Required]
        [StringLength(2)]
        public string DIA { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFEC { get; set; }

        [StringLength(30)]
        public string PERIODO { get; set; }

        public int? PRAZOBOLETO { get; set; }

        #endregion Public Properties
    }
}