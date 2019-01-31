namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Song")]
    public partial class Song
    {
        public int SongId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Length { get; set; }

        [Required]
        [StringLength(50)]
        public string Band { get; set; }

        public virtual Band Band1 { get; set; }
    }
}
