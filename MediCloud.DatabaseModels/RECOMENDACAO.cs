namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECOMENDACAO")]
    public partial class RECOMENDACAO
    {

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDREC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCGO { get; set; }

        public virtual CARGO CARGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDSETOR { get; set; }

        public virtual SETOR SETOR { get; set; }
    }
}
