namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TIPOSCONTRATOS
    {
        #region Public Properties

        public DateTime? DATACAD { get; set; }

        [StringLength(255)]
        public string DESCTIPCONT { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TIPCONT_ID { get; set; }

        [StringLength(40)]
        public string TITULOTIPCONT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VALORPADRAO { get; set; }

        #endregion Public Properties
    }
}