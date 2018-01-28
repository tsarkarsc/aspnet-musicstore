using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class ArtistAddForm
    {
        // Attention 01 - Data annotations are important on ALL Artist classes

        public ArtistAddForm()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        // For an individual, a birth name
        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        // Attention 06 - Note the DataType data annotations

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [Required]
        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        [Display(Name = "URL to artist photo")]
        [DataType(DataType.Url)]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }

        [StringLength(10000)]
        [Display(Name = "Artist profile")]
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }
    }

    public class ArtistAdd
    {
        public ArtistAdd()
        {
            BirthName = "";
        }

        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth date, or start date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(200)]
        [DataType(DataType.Url)]
        [Display(Name = "Artist photo")]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }

        [StringLength(10000)]
        [Display(Name = "Artist profile")]
        public string Profile { get; set; }
    }

    public class ArtistBase : ArtistAdd
    {
        public int Id { get; set; }

        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }
    }

    public class ArtistWithDetails : ArtistBase
    {
        [Display(Name = "Number of albums")]
        public int AlbumsCount { get; set; }
    }

    public class ArtistWithMediaItemStringIds : ArtistWithDetails
    {
        public ArtistWithMediaItemStringIds()
        {
            MediaItems = new List<MediaItemBase>();
        }

        public IEnumerable<MediaItemBase> MediaItems { get; set; }
    }
}