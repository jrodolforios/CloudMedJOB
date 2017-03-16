namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOVIMENTO_ARQUIVOS
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDARQUIVO { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] ARQUIVO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDMOV { get; set; }

        public virtual MOVIMENTO MOVIMENTO { get; set; }
    }
}