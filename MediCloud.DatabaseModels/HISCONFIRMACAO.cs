namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HISCONFIRMACAO")]
    public partial class HISCONFIRMACAO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDHISCONF { get; set; }

        [StringLength(50)]
        public string USUARIOREALIZADO { get; set; }

        public DateTime? DATAREALIZADO { get; set; }

        public int? IDMOVPRO { get; set; }
    }
}
