namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SELECTANUAL")]
    public partial class SELECTANUAL
    {
        #region Public Properties

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CARGO { get; set; }

        public DateTime? DATAMOV { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NOMEFANTASIA { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string PROCEDIMENTO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string PROXIMOANO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RAZAOSOCIAL { get; set; }

        #endregion Public Properties
    }
}