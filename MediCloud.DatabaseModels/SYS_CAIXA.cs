namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_CAIXA
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_CAIXA()
        {
            SYS_MAIL = new HashSet<SYS_MAIL>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODCAI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODCAI_1 { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_MAIL> SYS_MAIL { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        #endregion Public Properties
    }
}