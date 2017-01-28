namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTASORC")]
    public partial class CONTASORC
    {
        [StringLength(4)]
        public string CENTROCUSTO { get; set; }

        [Key]
        [StringLength(7)]
        public string CODIGO { get; set; }

        [StringLength(5)]
        public string CODIGOEXT { get; set; }

        public int NIVEL { get; set; }

        [Required]
        [StringLength(45)]
        public string NOME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERCENTUAL { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALOR { get; set; }
    }
}
