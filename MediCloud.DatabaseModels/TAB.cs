namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAB")]
    public partial class TAB
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDFOR { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        public virtual TABELAXFORNECEDORXPROCEDIMENTO TABELAXFORNECEDORXPROCEDIMENTO { get; set; }
    }
}
