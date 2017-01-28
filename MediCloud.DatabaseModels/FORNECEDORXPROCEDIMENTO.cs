namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FORNECEDORXPROCEDIMENTO")]
    public partial class FORNECEDORXPROCEDIMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORNECEDORXPROCEDIMENTO()
        {
            TABELAXFORNECEDORXPROCEDIMENTO = new HashSet<TABELAXFORNECEDORXPROCEDIMENTO>();
        }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDFOR { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        public decimal CUSTO { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }
    }
}
