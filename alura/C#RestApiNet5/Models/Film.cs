using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_RestApiNet5.Models
{
    public class Film
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Title field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Director field is required")]
        [StringLength(60)]
        public string Director { get; set; }

        [Required(ErrorMessage ="Category field is required")]
        public string Category { get; set; }

        [Range(1, 600, ErrorMessage ="Duration field must be a number between 1 and 600")]
        public int Duration { get; set; }
    }
}