namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_LAYOUT
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal COD { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME { get; set; }

        [StringLength(250)]
        public string DIRPADRAO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDUNICO { get; set; }

        [Column(TypeName = "image")]
        public byte[] REGRAS { get; set; }

        [Column(TypeName = "text")]
        public string LAYOUT { get; set; }

        [Column(TypeName = "text")]
        public string FILTRO { get; set; }

        public DateTime? DATALT { get; set; }

        [StringLength(1)]
        public string IMPEXP { get; set; }

        [StringLength(10)]
        public string EXTENSAO { get; set; }
    }
}
