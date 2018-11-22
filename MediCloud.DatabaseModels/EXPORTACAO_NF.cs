namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EXPORTACAO_NF
    {
        #region Public Properties

        [Key]
        [Column(Order = 7)]
        [StringLength(4)]
        public string ALIQUOTA { get; set; }

        [StringLength(10)]
        public string CEP { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string CODIGOCIDADE { get; set; }

        [StringLength(18)]
        public string CPFCNPJ { get; set; }

        [StringLength(10)]
        public string DATAEMISSAO { get; set; }

        [StringLength(8000)]
        public string DESCSERVPREST { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string EMAIL { get; set; }

        [StringLength(58)]
        public string ENDERECO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        [StringLength(8000)]
        public string ISS { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string ITEMLC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string LC116 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(3)]
        public string MUNICIPIO { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal NUMCONTROLE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QTDSOMA { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string TIPOCLIENTE { get; set; }

        [StringLength(8000)]
        public string TOTALNOTA { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        [StringLength(8000)]
        public string VALORSERVICO { get; set; }

        #endregion Public Properties
    }
}