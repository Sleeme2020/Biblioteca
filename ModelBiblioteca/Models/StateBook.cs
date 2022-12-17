using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Models
{
    public class StateBook
    {
        public int Id { get; set; }
        public TrafficDir TrafficDir { get; set; }
        public InstanceBook InstanseBook { get; set; }
        public override string ToString()
        {
            switch(TrafficDir)
            {
                case TrafficDir.inlibraly:
                    return "В библиотеке";

                case TrafficDir.inUser:
                    return "На руках";
                    default:
                    return "Статус не определен!";
            }
            
        }

    }
}
