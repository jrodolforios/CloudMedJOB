namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FORMADEPAGAMENTO")]
    public partial class FORMADEPAGAMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORMADEPAGAMENTO()
        {
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            CLIENTE_GRUPO = new HashSet<CLIENTE_GRUPO>();
            MOVIMENTO = new HashSet<MOVIMENTO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
        }

        #endregion Public Constructors



        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_GRUPO> CLIENTE_GRUPO { get; set; }

        [Column("FORMADEPAGAMENTO")]
        [Required]
        [StringLength(50)]
        public string FORMADEPAGAMENTO1 { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFORPAG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }

        [Required]
        [StringLength(50)]
        public string TIPOPAGTO { get; set; }

        #endregion Public Properties
    }
}