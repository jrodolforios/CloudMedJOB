namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SEQRECOMENDACAOXASO")]
    public partial class SEQRECOMENDACAOXASO
    {
        #region Public Properties

        [Key]
        public int CODIGO { get; set; }

        public int? FOOL { get; set; }

        #endregion Public Properties
    }
}