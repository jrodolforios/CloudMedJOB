namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_REFRULES
    {
        #region Public Properties

        [Column(TypeName = "image")]
        public byte[] CONTEUDO { get; set; }

        [Key]
        [StringLength(250)]
        public string NOME { get; set; }

        [Required]
        [StringLength(50)]
        public string VERSAO { get; set; }

        #endregion Public Properties
    }
}