namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_HELP
    {
        #region Public Properties

        [Required]
        [StringLength(1)]
        public string ALTERADO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODHELP { get; set; }

        [Required]
        [StringLength(50)]
        public string CONTEXTO { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        [StringLength(500)]
        public string PALAVRAS_CHAVE { get; set; }

        public virtual SYS_HELPBODY SYS_HELPBODY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TOPICO_IDX { get; set; }

        [StringLength(50)]
        public string TOPICO_PAI { get; set; }

        #endregion Public Properties
    }
}