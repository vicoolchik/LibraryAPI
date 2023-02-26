using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryInfrastructure.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
