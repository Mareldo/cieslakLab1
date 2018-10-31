using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Model
{
    public class BookAuthor
    {
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
