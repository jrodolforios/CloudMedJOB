namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PARAMETRO_TAB
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        #endregion Public Properties
    }
}