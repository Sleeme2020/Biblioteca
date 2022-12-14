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
    {
            return SingleTon.DB.InstanceBooks.Where(u=>u.Book==book).ToArray();
        }

    }
}
