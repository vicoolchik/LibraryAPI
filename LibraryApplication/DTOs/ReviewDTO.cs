using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
    }
}
