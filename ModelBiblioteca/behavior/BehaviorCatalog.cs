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
        public static void add(Category category,Category owner=null)
        {
            if (owner != null)
                owner.AddCategory(category);
            SingleTon.DB.Categories.Add(category);
            SingleTon.DB.SaveChanges();
            BehavorBook.updcat();

        }

        public static void Update(Category category)
        {
            SingleTon.DB.Categories.Update(category);
            SingleTon.DB.SaveChanges();
            BehavorBook.updcat();
        }
    }
}
