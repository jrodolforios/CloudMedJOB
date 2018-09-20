namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HISCONFIRMACAO")]
    public partial class HISCONFIRMACAO
    {
        #region Public Properties

        public DateTime? DATAREALIZADO { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDHISCONF { get; set; }

        public int? IDMOVPRO { get; set; }

        [StringLength(50)]
        public string USUARIOREALIZADO { get; set; }

        #endregion Public Properties
    }
}