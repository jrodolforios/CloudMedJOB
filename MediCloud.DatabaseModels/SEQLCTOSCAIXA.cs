namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEQLCTOSCAIXA")]
    public partial class SEQLCTOSCAIXA
    {
        [Key]
        public int CODIGO { get; set; }

        public int? FOOL { get; set; }
    }
}