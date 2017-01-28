namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEXTOPADRAO")]
    public partial class TEXTOPADRAO
    {
        public DateTime? DATACAD { get; set; }

        [StringLength(45)]
        public string NOME { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEX_ID { get; set; }

        [StringLength(255)]
        public string TEXTO { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }
    }
}
