namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QUANTIDADE_NOTAFISCAL
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDNF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTDSOMA { get; set; }
    }
}
