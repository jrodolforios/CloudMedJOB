namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TIPOSDOCTOS
    {
        #region Public Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [StringLength(45)]
        public string NOME { get; set; }

        [StringLength(255)]
        public string NOTAS { get; set; }

        #endregion Public Properties
    }
}