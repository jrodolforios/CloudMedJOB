namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PARAMETRO_TAB
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDTAB { get; set; }
    }
}
