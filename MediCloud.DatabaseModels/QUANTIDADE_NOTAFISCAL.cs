namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class QUANTIDADE_NOTAFISCAL
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDNF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTDSOMA { get; set; }

        #endregion Public Properties
    }
}