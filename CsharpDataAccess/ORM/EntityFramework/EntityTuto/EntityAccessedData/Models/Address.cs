using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityAccessedData.Models
{
    public class Adress {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string StreetAdress { get; set; }


        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar(12)")]
        public string ZipCode { get; set; }

    }
}