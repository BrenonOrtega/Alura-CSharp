using System.ComponentModel.DataAnnotations;

namespace C_RestApiNet5.Dtos
{
    public class CreateFilmDto  
    {
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