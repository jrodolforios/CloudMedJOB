namespace MediCloud.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TAB")]
    public partial class TAB
    {
        #region Public Properties

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDFOR { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDPRO { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IDTAB { get; set; }

        public virtual TABELAXFORNECEDORXPROCEDIMENTO TABELAXFORNECEDORXPROCEDIMENTO { get; set; }

        #endregion Public Properties
    }
}