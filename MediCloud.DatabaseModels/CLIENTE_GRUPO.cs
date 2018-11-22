namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_GRUPO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE_GRUPO()
        {
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
        }

        #endregion Public Constructors



        #region Public Properties

        [StringLength(15)]
        public string BAIRRO { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string CIDADE { get; set; }

        public virtual CIDADE CIDADE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [StringLength(15)]
        public string CPFCNPJ { get; set; }

        [StringLength(40)]
        public string ENDERECO { get; set; }

        [StringLength(50)]
        public string ENTREGA { get; set; }

        public virtual FORMADEPAGAMENTO FORMADEPAGAMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string GRUPO { get; set; }

        [StringLength(5)]
        public string IDBBCOBRANCA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCID { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCLIGRU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFEC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFORPAG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDROTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDSEG { get; set; }

        [StringLength(1)]
        public string IMPRIME { get; set; }

        [StringLength(15)]
        public string INSCESTADUAL { get; set; }

        [StringLength(15)]
        public string INSCMUNICIPAL { get; set; }

        public virtual MOVIMENTO_FECHAMENTO MOVIMENTO_FECHAMENTO { get; set; }

        [StringLength(1)]
        public string NF { get; set; }

        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }

        [Column(TypeName = "ntext")]
        public string OBSERVACOES { get; set; }

        [Column(TypeName = "text")]
        public string OBSNF { get; set; }

        public virtual ROTA ROTA { get; set; }

        public virtual SEGMENTO SEGMENTO { get; set; }

        [StringLength(1)]
        public string TIPOCLIENTE { get; set; }

        [StringLength(1)]
        public string TIPOEMPRESA { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        #endregion Public Properties
    }
}