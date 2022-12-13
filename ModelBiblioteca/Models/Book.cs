using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class Book:Category
    {
        public string Title { get; set; } = null!;
        public Autor Autor { get; set; } =null!;
        public int AutorId { get; set; }
        public DateTime PublicDate { get; set; }
        
        public List<InstanceBook> InstanceBooks { get; set; } 
        public List<WordKey> WordKeys { get; set; }

        public override void AddCategory(Category category)
        {
            if (category is not Book)
                base.AddCategory(category);
            else
                throw new ArgumentException("Book in book is never implement");
        }

        public override string ToString()
        {
            return $"{Name} - {Autor}";
        }

    }
}
