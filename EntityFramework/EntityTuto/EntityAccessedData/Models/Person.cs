using System.Collections.Generic;

namespace EntityAccessedData.Models
{
    public class Person
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Age { get; set; }
       public List<Email> Emails { get; set; } = new List<Email>();
       public List<Adress> Adresses { get; set; } = new List<Adress>();
        
    }
}