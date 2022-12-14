namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CLIENTE_CREDIARIO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE_CREDIARIO()
        {
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Required]
        [StringLength(15)]
        public string BAIRRO { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(50)]
        public string CIDADE { get; set; }

        public virtual CIDADE CIDADE1 { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        public virtual CLIENTE_GRUPO CLIENTE_GRUPO { get; set; }

        [StringLength(15)]
        public string CPFCNPJ { get; set; }

        [Required]
        [StringLength(40)]
        public string ENDERECO { get; set; }

        [StringLength(50)]
        public string ENTREGA { get; set; }

        public virtual FORMADEPAGAMENTO FORMADEPAGAMENTO { get; set; }

        [StringLength(5)]
        public string IDBBCOBRANCA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLIGRU { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDFEC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFORPAG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        [Required]
        [StringLength(1)]
        public string IMPRIME { get; set; }

        [StringLength(15)]
        public string INSCESTADUAL { get; set; }

        [StringLength(15)]
        public string INSCMUNICIPAL { get; set; }

        public virtual MOVIMENTO_FECHAMENTO MOVIMENTO_FECHAMENTO { get; set; }

        [StringLength(1)]
        public string NF { get; set; }

        [Column(TypeName = "text")]
        public string OBSNF { get; set; }

        [StringLength(40)]
        public string SACADO { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public virtual TABELA TABELA { get; set; }

        [StringLength(1)]
        public string TIPOEMPRESA { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }

        [StringLength(7)]
        public string USUARIO { get; set; }

        #endregion Public Properties
    }
}