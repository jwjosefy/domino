namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Campaign")]
    public partial class Campaign
    {
        public int id { get; set; }

        [StringLength(255)]
        public string descricao { get; set; }

        public float? desconto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? vigencia { get; set; }
    }
}
