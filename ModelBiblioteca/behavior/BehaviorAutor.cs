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
    public static class BehaviorAutor
    {
        public static Autor[] GetAutor()
        {
            SingleTon.DB.Autors.Load();
            return SingleTon.DB.Autors.ToArray();
        }

        public static Autor GetAutor(int id)
        {            
            return SingleTon.DB.Autors.Where(u=>u.Id==id).FirstOrDefault();
        }

        public static void AddAutor(Autor autor)
        {
            SingleTon.DB.Autors.Load();
            
            if(SingleTon.DB.Autors.Contains(autor))
            {
                SingleTon.DB.Autors.Update(autor);
            }else
            {
                SingleTon.DB.Autors.Add(autor);
            }
            SingleTon.DB.SaveChanges();
        }
    }
}
