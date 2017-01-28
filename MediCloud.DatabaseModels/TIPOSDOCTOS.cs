namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIPOSDOCTOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO { get; set; }

        public DateTime? DATACADASTRO { get; set; }

        [StringLength(45)]
        public string NOME { get; set; }

        [StringLength(255)]
        public string NOTAS { get; set; }
    }
}
