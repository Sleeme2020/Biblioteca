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
        public StateBook StateBook { get; set; }

        public InstanceBook NewState()
        {
            StateBook = new StateBook();
            StateBook.TrafficDir = TrafficDir.inlibraly;
            StateBook.InstanseBook = this;
            return this;
        }

        public override string ToString()
        {
            return $"{Number} - {StateBook}";
        }
    }
}
