namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_CONCORRENCIA
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODCONC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        [StringLength(1000)]
        public string CHAVEREG { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }
    }
}
