namespace MediCloud.DatabaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class BANCOS
    {
        #region Public Properties

        [StringLength(6)]
        public string AGENCIA { get; set; }

        [StringLength(25)]
        public string BAIRRO { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(25)]
        public string CIDADE { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        [StringLength(40)]
        public string CONTATO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [StringLength(45)]
        public string ENDERECO { get; set; }

        [StringLength(2)]
        public string ESTADO { get; set; }

        [StringLength(20)]
        public string FAX { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string NOME { get; set; }

        [StringLength(6)]
        public string NUMERO { get; set; }

        [StringLength(20)]
        public string TELEFONE { get; set; }

        [StringLength(45)]
        public string URL { get; set; }

        public decimal? VL_TARIFA { get; set; }

        #endregion Public Properties
    }
}