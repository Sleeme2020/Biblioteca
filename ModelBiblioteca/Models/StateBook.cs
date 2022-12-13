using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class StateBook
    {
        public int Id { get; set; }
        public TrafficDir TrafficDir { get; set; }
        public Book Book { get; set; } 
        public int BookId { get; set; }
    }
}
