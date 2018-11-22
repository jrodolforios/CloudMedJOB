namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class MOVIMENTO_ARQUIVOS
    {
        #region Public Properties

        [Column(TypeName = "varbinary")]
        [Required]
        public byte[] ARQUIVO { get; set; }

        public DateTime DATAENVIO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDARQUIVO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDMOV { get; set; }

        public virtual MOVIMENTO MOVIMENTO { get; set; }

        [StringLength(100)]
        public string NOMEARQUIVO { get; set; }

        #endregion Public Properties
    }
}