namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTRATOSFORNEC")]
    public partial class CONTRATOSFORNEC
    {
        public int? ANOFINAL { get; set; }

        public int? ANOINICIAL { get; set; }

        [StringLength(255)]
        public string ANOTACOES { get; set; }

        [StringLength(1)]
        public string ATIVO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CONTFOR_ID { get; set; }

        [StringLength(7)]
        public string CTAORC_ID { get; set; }

        public DateTime? DATACAD { get; set; }

        public DateTime? DATAFINREF { get; set; }

        public DateTime? DATAINATIVO { get; set; }

        public DateTime? DATAINIREF { get; set; }

        public int? DIAVCTO { get; set; }

        public int? FORNEC_ID { get; set; }

        [StringLength(70)]
        public string HISTORICOBASE { get; set; }

        public int? MESFINAL { get; set; }

        public int? MESINICIAL { get; set; }

        [StringLength(15)]
        public string NUMERO { get; set; }

        public int? TIPCONT_ID { get; set; }

        public int? TIPDOC_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALOR { get; set; }
    }
}
