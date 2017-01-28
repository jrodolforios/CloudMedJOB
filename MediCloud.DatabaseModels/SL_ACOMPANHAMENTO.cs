namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SL_ACOMPANHAMENTO
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public decimal? MINIMO { get; set; }
    }
}
