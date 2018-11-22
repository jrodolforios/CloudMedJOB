namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SLNFCL")]
    public partial class SLNFCL
    {
        #region Public Properties

        [StringLength(15)]
        public string BAIRRO { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string CIDADE { get; set; }

        [StringLength(15)]
        public string CPFCNPJ { get; set; }

        public DateTime? DATAEMISSAO { get; set; }

        public DateTime? DATAVENCIMENTO { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal DESCONTONOPRAZO { get; set; }

        [StringLength(40)]
        public string ENDERECO { get; set; }

        [StringLength(50)]
        public string ENTREGA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFORPAG { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDNF { get; set; }

        [StringLength(1)]
        public string IMPRIME { get; set; }

        [StringLength(15)]
        public string INSCESTADUAL { get; set; }

        [StringLength(15)]
        public string INSCMUNICIPAL { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal IRRFNF { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal ISSNF { get; set; }

        [StringLength(1)]
        public string NF { get; set; }

        [StringLength(50)]
        public string NUMNF { get; set; }

        [Column(TypeName = "text")]
        public string OBSNF { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal PISCOFINSCSSL { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        public decimal? TOTALNOTA { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        #endregion Public Properties
    }
}