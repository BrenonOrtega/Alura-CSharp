using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityAccessedData.Models
{
    public class Person
    {
       public int Id { get; set; }

       [Required]
       [MaxLength(50)]
       public string FirstName { get; set; }

       [Required]
       [MaxLength(50)]
       public string LastName { get; set; }

       [MaxLength(3)]
       public string Age { get; set; }
       public List<Email> Emails { get; set; } = new List<Email>();
       public List<Adress> Adresses { get; set; } = new List<Adress>();
        
    }
}