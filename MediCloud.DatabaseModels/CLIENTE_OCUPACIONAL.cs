namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTE_OCUPACIONAL
    {
        [Key]
        [StringLength(1)]
        public string PCMSO { get; set; }

        [StringLength(10)]
        public string CODNEXO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        public DateTime? EMISSAO { get; set; }

        public DateTime? VENCIMENTO { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACAO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NAODESEJA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPCMSO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPPRA { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual EPCMSO EPCMSO { get; set; }

        public virtual EPPRA EPPRA { get; set; }
    }
}
