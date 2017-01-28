namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_CFGGER
    {
        [Column(TypeName = "image")]
        public byte[] CHAVE { get; set; }

        public DateTime? DATALT { get; set; }

        [Column(TypeName = "image")]
        public byte[] BRADLL { get; set; }

        [Column(TypeName = "image")]
        public byte[] BRDLL { get; set; }

        [Column(TypeName = "image")]
        public byte[] BRCLASSESDLL { get; set; }

        [StringLength(100)]
        public string LOCKDBNAME { get; set; }

        [StringLength(250)]
        public string LOCKDBACTION { get; set; }

        public DateTime? DATADLL { get; set; }

        [Key]
        [StringLength(16)]
        public string VERSAO { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMGPRINC { get; set; }

        [StringLength(255)]
        public string ULTIMOACESSO { get; set; }
    }
}
