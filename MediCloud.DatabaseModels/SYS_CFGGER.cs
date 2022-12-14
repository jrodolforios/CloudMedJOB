namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_CFGGER
    {
        #region Public Properties

        [Column(TypeName = "image")]
        public byte[] BRADLL { get; set; }

        [Column(TypeName = "image")]
        public byte[] BRCLASSESDLL { get; set; }

        [Column(TypeName = "image")]
        public byte[] BRDLL { get; set; }

        [Column(TypeName = "image")]
        public byte[] CHAVE { get; set; }

        public DateTime? DATADLL { get; set; }
        public DateTime? DATALT { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMGPRINC { get; set; }

        [StringLength(250)]
        public string LOCKDBACTION { get; set; }

        [StringLength(100)]
        public string LOCKDBNAME { get; set; }

        [StringLength(255)]
        public string ULTIMOACESSO { get; set; }

        [Key]
        [StringLength(16)]
        public string VERSAO { get; set; }

        #endregion Public Properties
    }
}