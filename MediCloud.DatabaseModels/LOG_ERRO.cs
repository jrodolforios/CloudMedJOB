namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class LOG_ERRO
    {
        #region Public Properties

        [Required]
        public DateTime Data { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDLOG { get; set; }

        [Required]
        public string MESSAGE { get; set; }

        public string MESSAGE_INNER_EXCEPTION { get; set; }

        [Required]
        public string STACKTRACE { get; set; }

        public string URL { get; set; }

        #endregion Public Properties
    }
}