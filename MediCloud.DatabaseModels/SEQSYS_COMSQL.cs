namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;

    public partial class SEQSYS_COMSQL
    {
        #region Public Properties

        [Key]
        public int CODIGO { get; set; }

        public int? FOOL { get; set; }

        #endregion Public Properties
    }
}