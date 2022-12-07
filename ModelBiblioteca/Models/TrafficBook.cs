using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public enum TrafficDir
    {
        inlibraly=1,
        inUser=-1
    }
    public class TrafficBook
    {
        public DateTime Date {get;set;}
        public User? User {get;set;}
        public InstanceBook Instance { get; set; } = null!;

    }
}
