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
    public static class BehaviorUser
    {
        public static User[] GetUsers()
        {
            SingleTon.DB.Users.Load();
            return SingleTon.DB.Users.ToArray();
        }

        public static void AddUser(User user)
        {
            SingleTon.DB.Users.Add(user);
            SingleTon.DB.SaveChanges();
        }
    }
}
