namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;

    public partial class SEQMOVIMENTO_REFERENTE
    {
        #region Public Properties

        [Key]
        public int CODIGO { get; set; }

        public int? FOOL { get; set; }

        #endregion Public Properties
    }
}