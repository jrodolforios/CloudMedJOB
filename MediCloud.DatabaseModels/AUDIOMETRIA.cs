namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUDIOMETRIA")]
    public partial class AUDIOMETRIA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string AUDIOMETRO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime DATAULTIMACALIBRACAO { get; set; }
    }
}
