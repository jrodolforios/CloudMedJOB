namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CONTASBANCARIAS
    {
        #region Public Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        public int? CODIGOBANCO { get; set; }

        public DateTime? DATAABERTURA { get; set; }

        [StringLength(45)]
        public string GERENTE { get; set; }

        [StringLength(15)]
        public string NUMERO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SALDOINICIAL { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }

        #endregion Public Properties
    }
}