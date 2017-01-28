namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONT_MOV_CLI
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public int? QTD { get; set; }
    }
}
