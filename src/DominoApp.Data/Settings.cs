namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Settings")]
    public partial class Settings
    {
        public long id { get; set; }

        [Column("settings")]
        [StringLength(16777215)]
        public string Setting { get; set; }
    }
}
