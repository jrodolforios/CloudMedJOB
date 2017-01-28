namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_HELPBODY
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODHELP { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOHTML_ENG { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOHTML_ESP { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOHTML_PTB { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOTXT_ENG { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOTXT_ESP { get; set; }

        [Column(TypeName = "text")]
        public string CONTEUDOTXT_PTB { get; set; }

        public DateTime? DATALT { get; set; }

        public virtual SYS_HELP SYS_HELP { get; set; }
    }
}
