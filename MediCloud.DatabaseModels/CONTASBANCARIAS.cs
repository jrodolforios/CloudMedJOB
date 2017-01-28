namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTASBANCARIAS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        public int? CODIGOBANCO { get; set; }

        public DateTime? DATAABERTURA { get; set; }

        [StringLength(45)]
        public string GERENTE { get; set; }

        [StringLength(15)]
        public string NUMERO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SALDOINICIAL { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }
    }
}
