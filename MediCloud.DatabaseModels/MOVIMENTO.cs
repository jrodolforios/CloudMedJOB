namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOVIMENTO")]
    public partial class MOVIMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIMENTO()
        {
            MOVIMENTO_ARQUIVOS = new HashSet<MOVIMENTO_ARQUIVOS>();
            MOVIMENTO_PROCEDIMENTO = new HashSet<MOVIMENTO_PROCEDIMENTO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDMOV { get; set; }

        [StringLength(500)]
        public string OBSERVACAO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDFUN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFAT { get; set; }

        public DateTime DATA { get; set; }

        public decimal? FATURA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCGO { get; set; }

        [StringLength(20)]
        public string USUARIO { get; set; }

        public int? IDFCX { get; set; }

        public DateTime? DATAMOV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDFORPAG { get; set; }

        [StringLength(50)]
        public string TIPO { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public bool? CAIXAPENDENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDSETOR { get; set; }

        public virtual CARGO CARGO { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        public virtual FATURAMENTO FATURAMENTO { get; set; }

        public virtual FORMADEPAGAMENTO FORMADEPAGAMENTO { get; set; }

        public virtual FUNCIONARIO FUNCIONARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_ARQUIVOS> MOVIMENTO_ARQUIVOS { get; set; }

        public virtual MOVIMENTO_REFERENTE MOVIMENTO_REFERENTE { get; set; }

        public virtual SETOR SETOR { get; set; }

        public virtual TABELA TABELA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO_PROCEDIMENTO> MOVIMENTO_PROCEDIMENTO { get; set; }
    }
}
