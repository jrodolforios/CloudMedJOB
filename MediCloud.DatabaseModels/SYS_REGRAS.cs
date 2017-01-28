namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_REGRAS
    {
        [Required]
        [StringLength(250)]
        public string ASSINATURA { get; set; }

        [Required]
        [StringLength(1)]
        public string COMPILADO { get; set; }

        public DateTime? DATALT { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string EVENTO { get; set; }

        [Required]
        [StringLength(1)]
        public string EXECUCAO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string FORM { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(60)]
        public string OBJETO { get; set; }

        [Required]
        [StringLength(1)]
        public string PUBLICADO { get; set; }

        [Column(TypeName = "text")]
        public string SOURCE { get; set; }

        [Required]
        [StringLength(250)]
        public string TIPEVENTO { get; set; }

        [Required]
        [StringLength(250)]
        public string TIPOBJETO { get; set; }
    }
}
