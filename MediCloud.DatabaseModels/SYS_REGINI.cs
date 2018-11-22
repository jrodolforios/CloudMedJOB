namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_REGINI
    {
        #region Public Properties

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        [StringLength(1)]
        public string CONTEUDO_BLN { get; set; }

        public DateTime? CONTEUDO_DTE { get; set; }

        public double? CONTEUDO_FLT { get; set; }

        [StringLength(250)]
        public string CONTEUDO_STR { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDO_TXT { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string TOPICO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string VARIAVEL { get; set; }

        #endregion Public Properties
    }
}