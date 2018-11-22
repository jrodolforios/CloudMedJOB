namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAUDOAUD")]
    public partial class LAUDOAUD
    {
        #region Public Properties

        [Column(TypeName = "date")]
        public DateTime? DATAPROX { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLAUDO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDMOVPRO { get; set; }

        public virtual MOVIMENTO_PROCEDIMENTO MOVIMENTO_PROCEDIMENTO { get; set; }

        [StringLength(1000)]
        public string OBSERVACAO { get; set; }

        public int? OD1K { get; set; }
        public int? OD250 { get; set; }

        public int? OD2K { get; set; }
        public int? OD3K { get; set; }
        public int? OD4K { get; set; }
        public int? OD500 { get; set; }
        public int? OD6K { get; set; }

        public int? OD8K { get; set; }

        public int? ODO1K { get; set; }
        public int? ODO250 { get; set; }
        public int? ODO2K { get; set; }
        public int? ODO3K { get; set; }
        public int? ODO4K { get; set; }
        public int? ODO500 { get; set; }
        public int? ODO6K { get; set; }
        public int? ODO8K { get; set; }
        public int? OE1K { get; set; }
        public int? OE250 { get; set; }

        public int? OE2K { get; set; }
        public int? OE3K { get; set; }
        public int? OE4K { get; set; }
        public int? OE500 { get; set; }
        public int? OE6K { get; set; }

        public int? OE8K { get; set; }
        public int? OEO1K { get; set; }
        public int? OEO250 { get; set; }

        public int? OEO2K { get; set; }
        public int? OEO3K { get; set; }
        public int? OEO4K { get; set; }
        public int? OEO500 { get; set; }
        public int? OEO6K { get; set; }

        public int? OEO8K { get; set; }

        #endregion Public Properties
    }
}