namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NATUREZA")]
    public partial class NATUREZA
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDNAT { get; set; }

        [Column("NATUREZA")]
        [Required]
        [StringLength(50)]
        public string NATUREZA1 { get; set; }
    }
}
