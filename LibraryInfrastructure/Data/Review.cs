﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryInfrastructure.Data
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
