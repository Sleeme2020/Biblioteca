﻿using ModelBiblioteca.Models;
using ModelBiblioteca.Patterns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.behavior
{
    public static class BehaviorWordKey
    {
        public static WordKey[] GetWordKey(Book book)
        {
            return SingleTon.DB.WordKeys.Where(w => w.Books.Equals(book)).ToArray();
        }

        public static Book[] GetWordKeyBook(string s)
        {
            return SingleTon.DB.Books.Where(u => u.WordKeys.Any(c => EF.Functions.Like(c.Name, ""))).ToArray();
        }

        public static void AddWordKey(Book book, string s)
        {
            var Word = SingleTon.DB.WordKeys.Where(u => u.Name == s);
            if (Word.Count()>0)
            {
                foreach(var word in Word)
                {
                    word.Books.Add(book);
                }
                SingleTon.DB.AddRange(Word);
            }
            else
            {
                book.WordKeys.Add(new WordKey()
                {
                    Name =s                    
                });
                SingleTon.DB.Books.Add(book);
            }
            SingleTon.DB.SaveChanges();

        }
    }
}
