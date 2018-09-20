namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CLIENTE")]
    public partial class CLIENTE
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
            CLIENTE_OCUPACIONAL = new HashSet<CLIENTE_OCUPACIONAL>();
            CLIENTE_CONTATO = new HashSet<CLIENTE_CONTATO>();
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            CLIENTE_OUTRASEMP = new HashSet<CLIENTE_OUTRASEMP>();
            CONTRATO_FIXO_DET = new HashSet<CONTRATO_FIXO_DET>();
            FUNCIONARIO = new HashSet<FUNCIONARIO>();
            LAUDOAV = new HashSet<LAUDOAV>();
            MOVIMENTO = new HashSet<MOVIMENTO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
            TABELA = new HashSet<TABELA>();
        }

        #endregion Public Constructors



        #region Public Properties

        [StringLength(2)]
        public string ATIVIDADE { get; set; }

        [StringLength(15)]
        public string BAIRRO { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(50)]
        public string CIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTATO> CLIENTE_CONTATO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_OCUPACIONAL> CLIENTE_OCUPACIONAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_OUTRASEMP> CLIENTE_OUTRASEMP { get; set; }

        public virtual CONTADOR CONTADOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO_FIXO_DET> CONTRATO_FIXO_DET { get; set; }

        [StringLength(15)]
        public string CPFCNPJ { get; set; }

        public DateTime? DATAATUALIZACAO { get; set; }

        public DateTime? DATAULTIMOMOV { get; set; }

        [StringLength(100)]
        public string ENDERECO { get; set; }

        public virtual EPCMSO EPCMSO { get; set; }

        public virtual EPPRA EPPRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNCIONARIO> FUNCIONARIO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCONT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPCMSO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDEPPRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDROTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDSEG { get; set; }

        public bool? INATIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAUDOAV> LAUDOAV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        public int? NFUN { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMEFANTASIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }

        [Column(TypeName = "ntext")]
        public string OBSERVACOES { get; set; }

        [Required]
        [StringLength(100)]
        public string RAZAOSOCIAL { get; set; }

        public virtual ROTA ROTA { get; set; }

        public virtual SEGMENTO SEGMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELA> TABELA { get; set; }

        [StringLength(1)]
        public string TIPOCLIENTE { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        public int? ULTIMOIDMOV { get; set; }

        [StringLength(7)]
        public string USUARIO { get; set; }

        [StringLength(50)]
        public string USUARIOATUALIZACAO { get; set; }

        #endregion Public Properties
    }
}