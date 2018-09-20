namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PASTASMOV")]
    public partial class PASTASMOV
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PASTASMOV()
        {
            LCTOSCAIXA = new HashSet<LCTOSCAIXA>();
            LCTOSCAIXA1 = new HashSet<LCTOSCAIXA>();
        }

        #endregion Public Constructors



        #region Public Properties

        [StringLength(25)]
        public string BAIRRO { get; set; }

        public int? CAIXAS { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(14)]
        public string CGC { get; set; }

        [StringLength(25)]
        public string CIDADE { get; set; }

        [StringLength(14)]
        public string CNPJ { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CODIGO { get; set; }

        [StringLength(11)]
        public string CPF { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [StringLength(40)]
        public string EMAIL { get; set; }

        [StringLength(45)]
        public string ENDERECO { get; set; }

        [StringLength(2)]
        public string ESTADO { get; set; }

        [StringLength(20)]
        public string FAX { get; set; }

        [StringLength(255)]
        public string HISTORICO { get; set; }

        [StringLength(20)]
        public string INS_ESTADUAL { get; set; }

        [StringLength(20)]
        public string INS_MUNICIPAL { get; set; }

        [StringLength(255)]
        public string INSTRUCOES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCTOSCAIXA> LCTOSCAIXA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCTOSCAIXA> LCTOSCAIXA1 { get; set; }

        [StringLength(45)]
        public string NOME { get; set; }

        [StringLength(20)]
        public string TELEFONE1 { get; set; }

        [StringLength(20)]
        public string TELEFONE2 { get; set; }

        [StringLength(1)]
        public string TIPOPESSOA { get; set; }

        #endregion Public Properties
    }
}