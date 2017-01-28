namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("selectultimomovcli")]
    public partial class selectultimomovcli
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDMOV { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        public DateTime? DATAMOV { get; set; }
    }
}
