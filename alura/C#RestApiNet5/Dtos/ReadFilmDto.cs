using System;

namespace C_RestApiNet5.Dtos
{
    public class ReadFilmDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Director { get; set; }

        public string Category { get; set; }

        public int Duration { get; set; }
        
        public DateTime QueriedAt { get; set; } = DateTime.UtcNow;
    }
}