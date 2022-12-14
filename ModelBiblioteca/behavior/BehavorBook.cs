using Microsoft.EntityFrameworkCore;
using ModelBiblioteca.Models;
using ModelBiblioteca.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.behavior
{
    public static class BehavorBook
    {
        internal static void updcat()
        {
            books.Clear();
            books.AddRange(SingleTon.DB.Categories.ToArray());
        }
        static List<Category> books = new List<Category>();
        static BehavorBook()
        {
                SingleTon.DB.Autors.Load();
                SingleTon.DB.Categories.Load();
                books.AddRange(SingleTon.DB.Categories.ToArray());           
        }
        public static Category[] GetBook()
        {
            
            return books.Where(u=>u.GetType()==typeof(Book)).ToArray();
        }

        public static Category GetBook(int id)
        {
            
            return books.Where(u=>u.Id==id && u.GetType() == typeof(Book)).FirstOrDefault();
        }

        public static void update(Book book)
        {
            if(books.Contains(book))
            {
                SingleTon.DB.Update(book);
            }else
            {
                SingleTon.DB.Add(book);
            }
            SingleTon.DB.SaveChanges();
        }

        public static void Del(Book book)
        {
            if(books.Contains(book))
            {
                books.Remove(book);
                SingleTon.DB.Remove(book);
                SingleTon.DB.SaveChanges();
            }
        }

        public static Category[] GetCatalog()
        {
            return books.ToArray();
        }
        public static Category GetCatalog(int id)
        {
           return books.Where(u => u.Id == id).FirstOrDefault();
        }
        public static Category[] GetCatalogs(Category id)
        {
            return books.Where(u => u.Categor == id).ToArray();
        }

        public static Category[] GetCategory()
        {
            return books.Where(u=>u.GetType() == typeof(Category)).ToArray();
        }
        public static Category GetCategory(int id)
        {
            return books.Where(u => u.Id == id && u.GetType() == typeof(Category)).FirstOrDefault();
        }
        public static Category[] GetCategorys(Category id)
        {
            return books.Where(u => u.Categor == id && u.GetType() == typeof(Category)).ToArray();
        }
    }
}
