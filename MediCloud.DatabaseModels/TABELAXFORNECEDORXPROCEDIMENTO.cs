namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TABELAXFORNECEDORXPROCEDIMENTO")]
    public partial class TABELAXFORNECEDORXPROCEDIMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TABELAXFORNECEDORXPROCEDIMENTO()
        {
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        public decimal FATURAMENTO { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        public virtual FORNECEDORXPROCEDIMENTO FORNECEDORXPROCEDIMENTO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDFOR { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        public virtual TAB TAB { get; set; }

        public virtual TABELA TABELA { get; set; }

        #endregion Public Properties
    }
}