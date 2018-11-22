namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_LOGMSG
    {
        #region Public Properties

        [Required]
        [StringLength(50)]
        public string BOTAO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODMSG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU_DESTINATARIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU_REMETENTE { get; set; }

        [Required]
        [StringLength(1)]
        public string ENTREGUE { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MENSAGEM { get; set; }

        [StringLength(50)]
        public string RESPOSTA { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO1 { get; set; }

        #endregion Public Properties
    }
}