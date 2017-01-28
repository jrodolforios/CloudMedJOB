namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROCEDIMENTO")]
    public partial class PROCEDIMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROCEDIMENTO()
        {
            CONTRATO_FIXO_DET = new HashSet<CONTRATO_FIXO_DET>();
            FORNECEDORXPROCEDIMENTO = new HashSet<FORNECEDORXPROCEDIMENTO>();
            MOVIMENTO_PROCEDIMENTO = new HashSet<MOVIMENTO_PROCEDIMENTO>();
            CLIENTE_CONTRATOFIXO = new HashSet<CLIENTE_CONTRATOFIXO>();
            TABELAXFORNECEDORXPROCEDIMENTO = new HashSet<TABELAXFORNECEDORXPROCEDIMENTO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDPRO { get; set; }

        [Column("PROCEDIMENTO")]
        [Required]
        [StringLength(30)]
        public string PROCEDIMENTO1 { get; set; }

        [StringLength(50)]
        public string COMPLEMENTO { get; set; }

        [Required]
        [StringLength(6)]
        public string ABREVIADO { get; set; }

        [StringLength(10)]
        public string CODNEXO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDSUBGRUPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFOR { get; set; }

        public bool? ZERAAUTOMATICO { get; set; }

        public bool? CONFIRMARAUTOMATICO { get; set; }

        [StringLength(4)]
        public string IDPRF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTRATO_FIXO_DET> CONTRATO_FIXO_DET { get; set; }

        public virtual FORNECEDOR FORNECEDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORNECEDORXPROCEDIMENTO> FORNECEDORXPROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_PROCEDIMENTO> MOVIMENTO_PROCEDIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }

        public virtual PROFISSIONAIS PROFISSIONAIS { get; set; }

        public virtual PROCEDIMENTO_GRUPO_SUBGRUP PROCEDIMENTO_GRUPO_SUBGRUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }
    }
}
