using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Category Categor { get; set; } = null!;
        public int CategoryId { get; set; }
        public virtual void AddCategory(Category category)
        {
           Categor = category;
        }
    }
}
