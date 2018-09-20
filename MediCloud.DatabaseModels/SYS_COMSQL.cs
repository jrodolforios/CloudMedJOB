namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_COMSQL
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODCOMANDOSQL { get; set; }

        [Column(TypeName = "text")]
        public string CONSULTA { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        #endregion Public Properties
    }
}