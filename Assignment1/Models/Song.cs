namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public string Rating { get; set; }

        public int Fk_BandId { get; set; }

        public virtual Band Band { get; set; }
    }
}
