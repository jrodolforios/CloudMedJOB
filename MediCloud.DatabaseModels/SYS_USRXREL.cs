namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_USRXREL
    {
        #region Public Properties

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        [Column(TypeName = "image")]
        public byte[] CTRLACESSOREL { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        #endregion Public Properties
    }
}