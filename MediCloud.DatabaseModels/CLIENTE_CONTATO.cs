namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_CONTATO
    {
        #region Public Properties

        public virtual CLIENTE CLIENTE { get; set; }

        [Required]
        [StringLength(3)]
        public string DEPARTAMENTO { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(14)]
        public string FONEFIXO { get; set; }

        [StringLength(14)]
        public string FONEMOVEL { get; set; }

        [Required]
        [StringLength(30)]
        public string FUNCAO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCON { get; set; }

        public DateTime? NASCIMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME { get; set; }

        [StringLength(50)]
        public string OBS { get; set; }

        #endregion Public Properties
    }
}