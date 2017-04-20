namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INFORMACOES_CLINICA")]
    public partial class INFORMACOES_CLINICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFORMACOES_CLINICA()
        {
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDINFSIS { get; set; }

        [Required]
        [StringLength(500)]
        public string URLLOGO { get; set; }

        [Required]
        [StringLength(500)]
        public string NOMECLINICA { get; set; }

        [StringLength(1000)]
        public string DADOSCABECALHOREL { get; set; }

        [StringLength(500)]
        public string CIDADEESTADOCLINICA { get; set; }

        [StringLength(200)]
        public string ENDERECOCLINICA { get; set; }

        [StringLength(20)]
        public string TELEFONECLINICA { get; set; }

        [StringLength(200)]
        public string RAZAOSOCIAL { get; set; }

        [StringLength(20)]
        public string CNPJ { get; set; }
    }
}
