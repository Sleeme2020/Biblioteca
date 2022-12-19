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
        public int Id { get; set; }
        public DateTime Date {get;set;}
        public User? User {get;set;}
        public InstanceBook Instance { get; set; } = null!;
        public TrafficDir TrafficDir { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Date} {User} - {Instance.Number} ");
            switch (TrafficDir)
            {
                case TrafficDir.inlibraly:
                    return stringBuilder.Append("вернул в библиотеку").ToString();

                case TrafficDir.inUser:
                    return stringBuilder.Append("взял себе").ToString();
                default:
                    return "Статус не определен!";
            }
        }
    }
}
