namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RECOMENDACAO")]
    public partial class RECOMENDACAO
    {
        #region Public Properties

        public virtual CARGO CARGO { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDREC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDSETOR { get; set; }

        public virtual SETOR SETOR { get; set; }

        #endregion Public Properties
    }
}