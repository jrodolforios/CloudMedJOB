namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOV_PROC_COMPLETO
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDMov { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Cliente { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Funcionário { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Data_Procedimento { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Fornecedor { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(30)]
        public string Procedimento { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal IDMovPro { get; set; }

        [StringLength(50)]
        public string Observacao_Procedimento { get; set; }

        public decimal? Valor { get; set; }

        public decimal? Desconto { get; set; }

        public decimal? Total { get; set; }

        [StringLength(10)]
        public string Usuário { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Profissional { get; set; }

        [StringLength(50)]
        public string Observacao { get; set; }

        public DateTime? Data_Realizado { get; set; }

        [StringLength(10)]
        public string Usuario_Realizado { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime Data_Movimento { get; set; }

        public int? Fechamento_Caixa { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Faturamento { get; set; }
    }
}
