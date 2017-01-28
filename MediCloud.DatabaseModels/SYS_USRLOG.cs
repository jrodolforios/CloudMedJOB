namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRLOG
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        public DateTime? DATALT { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "text")]
        public string DESCRICAO { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }
    }
}
