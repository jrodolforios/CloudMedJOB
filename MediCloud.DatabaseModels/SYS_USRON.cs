namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_USRON
    {
        #region Public Properties

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CODUSU { get; set; }

        public DateTime? DATA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string IP { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        [Required]
        [StringLength(16)]
        public string VERSAO { get; set; }

        #endregion Public Properties
    }
}