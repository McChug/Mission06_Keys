using System.ComponentModel.DataAnnotations;

namespace Mission06_Keys.Models
{
    public class MovieEntry
    {
        [Key]
        [Required]
        public int EntryId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        // Don't accept years outside of 1800-3000
        [Range(1800, 3000)]
        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
