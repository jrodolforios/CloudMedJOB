namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTE_OUTRASEMP
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDEMP { get; set; }

        [Required]
        [StringLength(50)]
        public string EMPRESA { get; set; }

        [StringLength(15)]
        public string TELEFONE { get; set; }

        [StringLength(50)]
        public string NOMERESP { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }
    }
}
