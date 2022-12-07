using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class WordKey
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Book> Books { get; set; }
    }
}
