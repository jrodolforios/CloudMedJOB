namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_CONSULTA
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODCONSULTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODPRO { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] ESTRDIAGRAMA { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPODIAGR { get; set; }
    }
}
