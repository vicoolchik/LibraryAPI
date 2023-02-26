using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.DTOs
{
    public class BookDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
    }
}
