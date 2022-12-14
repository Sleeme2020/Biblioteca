using ModelBiblioteca.Models;
using ModelBiblioteca.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ModelBiblioteca.behavior
{
    public static class BehaviorInstanse
    {
        public static void Add(InstanceBook instanceBook)
        {
            SingleTon.DB.InstanceBooks.Add(instanceBook);
            SingleTon.DB.SaveChanges();
        }

        public static InstanceBook[] GetInstanceBooks()
        {
            SingleTon.DB.InstanceBooks.Load();
            return SingleTon.DB.InstanceBooks.ToArray();
        }

        public static InstanceBook[] GetInstanceBooks(Book book)
        {
            return SingleTon.DB.InstanceBooks.Where(u=>u.Book==book).ToArray();
        }

    }
}
