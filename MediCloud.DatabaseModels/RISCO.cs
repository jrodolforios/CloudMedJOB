namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RISCO")]
    public partial class RISCO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDRISCO { get; set; }

        [Column("RISCO")]
        [Required]
        [StringLength(50)]
        public string RISCO1 { get; set; }

        [Required]
        [StringLength(50)]
        public string EVENTUALIDADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDNAT { get; set; }
    }
}
