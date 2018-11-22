namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_OCUPACIONAL
    {
        #region Public Properties

        public virtual CLIENTE CLIENTE { get; set; }

        [StringLength(10)]
        public string CODNEXO { get; set; }

        public DateTime? EMISSAO { get; set; }

        public virtual EPCMSO EPCMSO { get; set; }

        public virtual EPPRA EPPRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCLIOC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPCMSO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPPRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NAODESEJA { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACAO { get; set; }

        [StringLength(1)]
        public string PCMSO { get; set; }

        public DateTime? VENCIMENTO { get; set; }

        #endregion Public Properties
    }
}