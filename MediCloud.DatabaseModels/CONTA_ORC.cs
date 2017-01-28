namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTA_ORC
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal NUMCTAORC { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMECONTAORC { get; set; }

        [Required]
        [StringLength(1)]
        public string DEBCRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDGRUCTA { get; set; }

        public virtual CONTA_ORC_GRU CONTA_ORC_GRU { get; set; }
    }
}
