using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class InstanceBook
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public Book Book { get; set; } = null!;
        public int BookId { get; set; }
        public StateBook? StateBook { get; set; }
    }
}
