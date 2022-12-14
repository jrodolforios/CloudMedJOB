namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FORNECEDOR")]
    public partial class FORNECEDOR
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORNECEDOR()
        {
            CONTRATO_FIXO = new HashSet<CONTRATO_FIXO>();
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
            FORNECEDOR_CONTATO = new HashSet<FORNECEDOR_CONTATO>();
            FORNECEDORXPROCEDIMENTO = new HashSet<FORNECEDORXPROCEDIMENTO>();
            MOVIMENTO_PROCEDIMENTO = new HashSet<MOVIMENTO_PROCEDIMENTO>();
            PROCEDIMENTO = new HashSet<PROCEDIMENTO>();
            TABELAXFORNECEDORXPROCEDIMENTO = new HashSet<TABELAXFORNECEDORXPROCEDIMENTO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [StringLength(15)]
        public string BAIRRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        [StringLength(50)]
        public string CNPJ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO_FIXO> CONTRATO_FIXO { get; set; }

        [StringLength(6)]
        public string CTAAGENCIA { get; set; }

        [StringLength(3)]
        public string CTABANCO { get; set; }

        [StringLength(10)]
        public string CTACORRENTE { get; set; }

        [StringLength(40)]
        public string ENDERECO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDOR_CONTATO> FORNECEDOR_CONTATO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDORXPROCEDIMENTO> FORNECEDORXPROCEDIMENTO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_PROCEDIMENTO> MOVIMENTO_PROCEDIMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROCEDIMENTO> PROCEDIMENTO { get; set; }

        [Required]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }

        [StringLength(1)]
        public string TIPOCONTA { get; set; }

        public bool? TIPOFORNECEDOR { get; set; }

        #endregion Public Properties
    }
}