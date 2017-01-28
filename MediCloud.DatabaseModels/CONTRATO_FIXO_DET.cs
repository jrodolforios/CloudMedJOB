namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTRATO_FIXO_DET
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLANCONTFIX { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDMOV { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDLAN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDTAB { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual CONTRATO_FIXO CONTRATO_FIXO { get; set; }

        public virtual PROCEDIMENTO PROCEDIMENTO { get; set; }

        public virtual TABELA TABELA { get; set; }
    }
}
