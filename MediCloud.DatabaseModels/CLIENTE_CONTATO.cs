namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLIENTE_CONTATO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCON { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME { get; set; }

        public DateTime? NASCIMENTO { get; set; }

        [Required]
        [StringLength(3)]
        public string DEPARTAMENTO { get; set; }

        [Required]
        [StringLength(30)]
        public string FUNCAO { get; set; }

        [StringLength(14)]
        public string FONEFIXO { get; set; }

        [StringLength(14)]
        public string FONEMOVEL { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string OBS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }
    }
}
