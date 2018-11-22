namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;

    public partial class SEQSYS_FICHATECNICA
    {
        #region Public Properties

        [Key]
        public int CODCATEGORIA { get; set; }

        public int? FOOL { get; set; }

        #endregion Public Properties
    }
}