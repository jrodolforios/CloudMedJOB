namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CONT_MOV_CLI
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        public int? QTD { get; set; }

        #endregion Public Properties
    }
}