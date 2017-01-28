namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USRXREL
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        [Column(TypeName = "image")]
        public byte[] CTRLACESSOREL { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }
    }
}
