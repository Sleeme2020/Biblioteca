using ModelBiblioteca.Models;
using ModelBiblioteca.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.behavior
{
    public class BehaviorCatalog
    {
        public void add(Category category,Category owner=null)
        {
            if (owner != null)
                category.Categor = owner;
            SingleTon.DB.Add(category);
            SingleTon.DB.SaveChanges();

        }
    }
}
