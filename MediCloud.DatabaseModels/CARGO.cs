namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CARGO")]
    public partial class CARGO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARGO()
        {
            LAUDOAV = new HashSet<LAUDOAV>();
            MOVIMENTO = new HashSet<MOVIMENTO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [StringLength(30)]
        public string ABREVIADO { get; set; }

        [Column("CARGO")]
        [Required]
        [StringLength(50)]
        public string CARGO1 { get; set; }

        [StringLength(10)]
        public string CODNEXO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAUDOAV> LAUDOAV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        #endregion Public Properties
    }
}