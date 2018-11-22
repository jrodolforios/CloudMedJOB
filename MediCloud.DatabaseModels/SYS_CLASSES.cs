namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_CLASSES
    {
        #region Public Properties

        [Key]
        [StringLength(60)]
        public string CLASSE { get; set; }

        [Required]
        [StringLength(1)]
        public string COMPILADO { get; set; }

        public DateTime? DATALT { get; set; }

        [Required]
        [StringLength(1)]
        public string PUBLICADO { get; set; }

        [Column(TypeName = "text")]
        public string SOURCE { get; set; }

        #endregion Public Properties
    }
}