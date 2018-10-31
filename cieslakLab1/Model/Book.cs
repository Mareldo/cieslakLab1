using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Model
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public IEnumerable<BookAuthor> Authors { get; set; }
    }
}
