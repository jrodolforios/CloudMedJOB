namespace MediCloud.DatabaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TABELA")]
    public partial class TABELA
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TABELA()
        {
            CLIENTE_CREDIARIO = new HashSet<CLIENTE_CREDIARIO>();
            CONTRATO_FIXO_DET = new HashSet<CONTRATO_FIXO_DET>();
            MOVIMENTO = new HashSet<MOVIMENTO>();
            PARAMETRO = new HashSet<PARAMETRO>();
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
            TABELAXFORNECEDORXPROCEDIMENTO = new HashSet<TABELAXFORNECEDORXPROCEDIMENTO>();
            CLIENTE = new HashSet<CLIENTE>();
        }

        #endregion Public Constructors



        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO_FIXO_DET> CONTRATO_FIXO_DET { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDTAB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARAMETRO> PARAMETRO { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [Column("TABELA")]
        [Required]
        [StringLength(30)]
        public string TABELA1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }

        [StringLength(1)]
        public string TIPOPAGTO { get; set; }

        #endregion Public Properties
    }
}