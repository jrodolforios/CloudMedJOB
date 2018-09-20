namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_USRCOLUMN
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_USRCOLUMN()
        {
            SYS_USRCOMPONENT = new HashSet<SYS_USRCOMPONENT>();
            SYS_USUARIO = new HashSet<SYS_USUARIO>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Required]
        [StringLength(1)]
        public string CHAVE_PK { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODUSRCOLUMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSRTABLE { get; set; }

        public DateTime? DATALT { get; set; }

        public int? DECIMAIS { get; set; }

        [StringLength(200)]
        public string DESCRICAO { get; set; }

        [Required]
        [StringLength(150)]
        public string NOME { get; set; }

        [Required]
        [StringLength(1)]
        public string OBRIGATORIO { get; set; }

        public int? POSICAO_PK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOMPONENT> SYS_USRCOMPONENT { get; set; }

        public virtual SYS_USRTABLE SYS_USRTABLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USUARIO> SYS_USUARIO { get; set; }

        public int? TAMANHO { get; set; }

        [Required]
        [StringLength(300)]
        public string TIPO { get; set; }

        [Column(TypeName = "text")]
        public string VALOR_PADRAO { get; set; }

        #endregion Public Properties
    }
}