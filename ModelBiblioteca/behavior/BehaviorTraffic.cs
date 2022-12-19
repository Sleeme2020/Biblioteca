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
    public static class BehaviorTraffic
    {
        public static TrafficBook[] GetTrafficBooks()
        {
            SingleTon.DB.TrafficBooks.Include(u=>u.User).Load();
            return SingleTon.DB.TrafficBooks.ToArray();
        }

        public static TrafficBook[] GetTrafficBooks(InstanceBook book)
        {
            return SingleTon.DB.TrafficBooks.Include(u => u.User).Where(u => u.Instance == book).ToArray();
        }

        public static void SetTrafficBook( TrafficBook trafficBook)
        {
            SingleTon.DB.TrafficBooks.Add(trafficBook);
            var inst =SingleTon.DB.StateBooks.Where(u => u.InstanseBook == trafficBook.Instance).FirstOrDefault();
            inst.TrafficDir = trafficBook.TrafficDir;
            SingleTon.DB.Update(inst);
            SingleTon.DB.SaveChanges();
        }
    }
}
