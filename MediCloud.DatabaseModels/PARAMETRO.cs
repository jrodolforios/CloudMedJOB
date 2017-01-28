namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARAMETRO")]
    public partial class PARAMETRO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDPAR { get; set; }

        [Required]
        [StringLength(50)]
        public string SENHATRANSFERIRMOV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDTAB { get; set; }

        public virtual TABELA TABELA { get; set; }
    }
}
