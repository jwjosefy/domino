namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Movements")]
    public partial class Movements
    {
        public int id { get; set; }

        [StringLength(45)]
        public string move { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? move_timestamp { get; set; }

        public int User_id { get; set; }

        public int Session_id { get; set; }

        public virtual User User { get; set; }

        public virtual Session Session { get; set; }
    }
}
