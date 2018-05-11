using System;
using System.Collections.Generic;
using SQLite;

namespace Potm.Data
{
    [Table("favs")]
    public class Favourite
    {
        [PrimaryKey, Unique]
        public int clubId { get; set; }

        [MaxLength(250)]
        public string clubName { get; set; }

        [MaxLength(250)]
        public string clubLogo { get; set; }

        [MaxLength(250)]
        public string teamName { get; set; }

        [MaxLength(250)]
        public string teamGender { get; set; }
    }
}
