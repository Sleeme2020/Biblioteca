using ModelBiblioteca.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Patterns
{
    public static class SingleTon
    {
        public static AppContextDB DB { get; set; }

        static SingleTon()
        {
            DB = new AppContextDB();
        }
    }
}
