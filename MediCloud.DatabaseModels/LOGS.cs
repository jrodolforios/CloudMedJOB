namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOGS
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLOG { get; set; }

        [Required]
        [StringLength(50)]
        public string TIPO { get; set; }

        [Required]
        [StringLength(300)]
        public string OBSERVACAO { get; set; }
    }
}
