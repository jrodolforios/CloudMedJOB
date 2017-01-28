namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slmovxrec")]
    public partial class slmovxrec
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDREC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCLI { get; set; }

        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDCGO { get; set; }

        [StringLength(50)]
        public string CARGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDREF { get; set; }

        [StringLength(50)]
        public string NOMEREFERENCIA { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDPROREC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string REALIZADO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDPRO { get; set; }

        [StringLength(30)]
        public string PROCEDIMENTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDMOV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IDFUN { get; set; }

        [StringLength(50)]
        public string FUNCIONARIO { get; set; }

        public DateTime? DATAMOV { get; set; }

        public DateTime? DATAREALIZADO { get; set; }

        public decimal? TOTAL { get; set; }

        [StringLength(10)]
        public string USUARIO { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string CONFIRMADO { get; set; }
    }
}
