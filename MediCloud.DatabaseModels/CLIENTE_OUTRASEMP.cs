namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_OUTRASEMP
    {
        #region Public Properties

        public virtual CLIENTE CLIENTE { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string EMPRESA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDEMP { get; set; }

        [StringLength(50)]
        public string NOMERESP { get; set; }

        [StringLength(15)]
        public string TELEFONE { get; set; }

        #endregion Public Properties
    }
}