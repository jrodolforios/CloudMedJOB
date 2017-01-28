namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECOMENDACAOXASOXPRO")]
    public partial class RECOMENDACAOXASOXPRO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRECPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDRECASO { get; set; }

        public virtual RECOMENDACAOXASO RECOMENDACAOXASO { get; set; }
    }
}
