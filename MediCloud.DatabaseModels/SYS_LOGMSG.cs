namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_LOGMSG
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODMSG { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MENSAGEM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU_REMETENTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CODUSU_DESTINATARIO { get; set; }

        [Required]
        [StringLength(50)]
        public string BOTAO { get; set; }

        [StringLength(50)]
        public string RESPOSTA { get; set; }

        [Required]
        [StringLength(1)]
        public string ENTREGUE { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO1 { get; set; }
    }
}
