namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AUDIOMETRIA")]
    public partial class AUDIOMETRIA
    {
        #region Public Properties

        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string AUDIOMETRO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime DATAULTIMACALIBRACAO { get; set; }

        #endregion Public Properties
    }
}