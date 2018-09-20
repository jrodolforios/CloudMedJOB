namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("COMPOSICOESCAIXA")]
    public partial class COMPOSICOESCAIXA
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPOSICOESCAIXA()
        {
            LCTOSCAIXA = new HashSet<LCTOSCAIXA>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODIGO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCTOSCAIXA> LCTOSCAIXA { get; set; }

        [StringLength(40)]
        public string NOME { get; set; }

        [StringLength(255)]
        public string NOTAS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SALDOATUAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SALDOIMPLANTADO { get; set; }

        #endregion Public Properties
    }
}