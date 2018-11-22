namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_LTELA
    {
        #region Public Properties

        [StringLength(100)]
        public string CATEGORIA_FT { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODLTELA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODUSU { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMECOMPONENTE { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMEFORM { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] PROPCOMPONENTE { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        #endregion Public Properties
    }
}