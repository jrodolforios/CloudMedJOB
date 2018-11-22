namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_CONCORRENCIA
    {
        #region Public Properties

        [StringLength(1000)]
        public string CHAVEREG { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODCONC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        #endregion Public Properties
    }
}