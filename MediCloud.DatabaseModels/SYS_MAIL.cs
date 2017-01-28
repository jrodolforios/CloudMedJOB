namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_MAIL
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODMAI { get; set; }

        [StringLength(250)]
        public string ASSUNTO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CODCAI { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        public DateTime? DATALT { get; set; }

        public DateTime? DATCRIA { get; set; }

        public DateTime? DATSENT { get; set; }

        public DateTime? DATVIEW { get; set; }

        [StringLength(250)]
        public string DESTCC { get; set; }

        [StringLength(250)]
        public string DESTPARA { get; set; }

        [StringLength(1)]
        public string EMAILLIDO { get; set; }

        [StringLength(250)]
        public string MESSAGEID { get; set; }

        [StringLength(250)]
        public string REMETENTE { get; set; }

        [Column(TypeName = "text")]
        public string SOURCE { get; set; }

        public double? TAMANHO { get; set; }

        [StringLength(1)]
        public string TEMANEXOS { get; set; }

        public virtual SYS_CAIXA SYS_CAIXA { get; set; }
    }
}
