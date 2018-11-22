namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NOTAFISCAL")]
    public partial class NOTAFISCAL
    {
        #region Public Properties

        [StringLength(15)]
        public string BAIRRO { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string CIDADE { get; set; }

        public virtual CIDADE CIDADE1 { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual CLIENTE_GRUPO CLIENTE_GRUPO { get; set; }

        [StringLength(15)]
        public string CPFCNPJ { get; set; }

        public DateTime? DATAEMISSAO { get; set; }

        public DateTime? DATAVENCIMENTO { get; set; }

        public decimal? DESCONTONOPRAZO { get; set; }

        [StringLength(40)]
        public string ENDERECO { get; set; }

        [StringLength(50)]
        public string ENTREGA { get; set; }

        public virtual FATURAMENTO FATURAMENTO { get; set; }

        public virtual FORMADEPAGAMENTO FORMADEPAGAMENTO { get; set; }

        [StringLength(5)]
        public string IDBBCOBRANCA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLIGRU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFORPAG { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDNF { get; set; }

        [StringLength(1)]
        public string IMPRIME { get; set; }

        [StringLength(15)]
        public string INSCESTADUAL { get; set; }

        [StringLength(15)]
        public string INSCMUNICIPAL { get; set; }

        public decimal? IRRFNF { get; set; }

        public decimal? ISSNF { get; set; }

        [StringLength(1)]
        public string NF { get; set; }

        [StringLength(50)]
        public string NUMNF { get; set; }

        [Column(TypeName = "text")]
        public string OBSNF { get; set; }

        public decimal? PISCOFINSCSSL { get; set; }

        [Required]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        public decimal? TOTALNOTA { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        #endregion Public Properties
    }
}