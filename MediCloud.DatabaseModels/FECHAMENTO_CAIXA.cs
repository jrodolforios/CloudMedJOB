namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FECHAMENTO_CAIXA
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFCX { get; set; }

        public DateTime DATA { get; set; }

        [StringLength(20)]
        public string USUARIO { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACOES { get; set; }

        public DateTime? DATA_FECHAMENTO { get; set; }

        [Required]
        [StringLength(1)]
        public string PERIODO { get; set; }

        public decimal? TOTAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QUANTIDADE { get; set; }
    }
}
