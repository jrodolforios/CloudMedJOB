namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRFORMXTABLE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODFORM { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CODTABLE { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPOFORM { get; set; }

        public virtual SYS_USRFORM SYS_USRFORM { get; set; }

        public virtual SYS_USRTABLE SYS_USRTABLE { get; set; }
    }
}
