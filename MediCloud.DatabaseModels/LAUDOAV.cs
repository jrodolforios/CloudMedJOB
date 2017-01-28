namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LAUDOAV")]
    public partial class LAUDOAV
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLAUDO { get; set; }

        [Required]
        [StringLength(50)]
        public string CORRECAO { get; set; }

        [Required]
        [StringLength(50)]
        public string ESTRABISMO { get; set; }

        [Required]
        [StringLength(50)]
        public string VISAOCROMATICA { get; set; }

        public DateTime DATALAUDO { get; set; }

        [Required]
        [StringLength(50)]
        public string OD { get; set; }

        [Required]
        [StringLength(50)]
        public string OE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFUN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCGO { get; set; }

        [StringLength(500)]
        public string CONCLUSAO { get; set; }

        [StringLength(50)]
        public string COD { get; set; }

        [StringLength(50)]
        public string COE { get; set; }

        public virtual CARGO CARGO { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual FUNCIONARIO FUNCIONARIO { get; set; }
    }
}
