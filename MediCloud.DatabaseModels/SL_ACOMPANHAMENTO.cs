namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SL_ACOMPANHAMENTO
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public decimal? MINIMO { get; set; }

        #endregion Public Properties
    }
}