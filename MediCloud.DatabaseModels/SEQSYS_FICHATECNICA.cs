namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SEQSYS_FICHATECNICA
    {
        [Key]
        public int CODCATEGORIA { get; set; }

        public int? FOOL { get; set; }
    }
}
