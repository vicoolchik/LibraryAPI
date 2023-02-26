using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.DTOs
{
    public class SaveBookDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
