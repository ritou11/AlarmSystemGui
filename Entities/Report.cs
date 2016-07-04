using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmSystem.Entities
{
    public class Report
    {
        public bool IsShaking { get; set; }

        public int Illuminance { get; set; }

        public double Distance { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
