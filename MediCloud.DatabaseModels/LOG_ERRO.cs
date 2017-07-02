namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOG_ERRO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLOG { get; set; }

        public string URL { get; set; }

        public string MESSAGE_INNER_EXCEPTION { get; set; }

        [Required]
        public string MESSAGE { get; set; }

        [Required]
        public string STACKTRACE { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
