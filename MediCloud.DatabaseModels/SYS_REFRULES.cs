namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_REFRULES
    {
        [Key]
        [StringLength(250)]
        public string NOME { get; set; }

        [Required]
        [StringLength(50)]
        public string VERSAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONTEUDO { get; set; }
    }
}
