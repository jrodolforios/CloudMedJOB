namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_CLASSES
    {
        [Key]
        [StringLength(60)]
        public string CLASSE { get; set; }

        [Required]
        [StringLength(1)]
        public string PUBLICADO { get; set; }

        [Required]
        [StringLength(1)]
        public string COMPILADO { get; set; }

        [Column(TypeName = "text")]
        public string SOURCE { get; set; }

        public DateTime? DATALT { get; set; }
    }
}
