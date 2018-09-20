namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FATURAMENTO")]
    public partial class FATURAMENTO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FATURAMENTO()
        {
            MOVIMENTO = new HashSet<MOVIMENTO>();
            NOTAFISCAL = new HashSet<NOTAFISCAL>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Column(TypeName = "numeric")]
        public decimal ANO { get; set; }

        public DateTime DATA { get; set; }

        public DateTime? DATALIMITE { get; set; }

        [Required]
        [StringLength(2)]
        public string DIA { get; set; }

        public int IDCLI_FIN { get; set; }

        public int IDCLI_INI { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDFAT { get; set; }

        [Required]
        [StringLength(3)]
        public string MES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMENTO> MOVIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAFISCAL> NOTAFISCAL { get; set; }

        [StringLength(7)]
        public string USUARIO { get; set; }

        public decimal? VALOR { get; set; }

        #endregion Public Properties
    }
}