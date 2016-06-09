namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Transactions")]
    public partial class Transactions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string tipo { get; set; }

        public float? valor { get; set; }

        public int? quantidade { get; set; }

        public int User_id { get; set; }

        public virtual User User { get; set; }
    }
}
