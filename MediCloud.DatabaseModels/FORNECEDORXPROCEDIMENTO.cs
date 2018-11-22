namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FORNECEDORXPROCEDIMENTO")]
    public partial class FORNECEDORXPROCEDIMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORNECEDORXPROCEDIMENTO()
        {
            TABELAXFORNECEDORXPROCEDIMENTO = new HashSet<TABELAXFORNECEDORXPROCEDIMENTO>();
        }

        #endregion Public Constructors



        #region Public Properties

        public decimal CUSTO { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDFOR { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }

        #endregion Public Properties
    }
}