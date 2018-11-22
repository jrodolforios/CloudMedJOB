namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_LAYOUT
    {
        #region Public Properties

        [Column(TypeName = "numeric")]
        public decimal COD { get; set; }

        public DateTime? DATALT { get; set; }

        [StringLength(250)]
        public string DIRPADRAO { get; set; }

        [StringLength(10)]
        public string EXTENSAO { get; set; }

        [Column(TypeName = "text")]
        public string FILTRO { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDUNICO { get; set; }

        [StringLength(1)]
        public string IMPEXP { get; set; }

        [Column(TypeName = "text")]
        public string LAYOUT { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME { get; set; }

        [Column(TypeName = "image")]
        public byte[] REGRAS { get; set; }

        #endregion Public Properties
    }
}