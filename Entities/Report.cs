using System;

namespace AlarmSystem.Entities
{
    public class Report
    {
        public bool IsShaking { get; set; }

        public int Illuminance { get; set; }

        public double Distance { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool IsBuzzerOn { get; set; }

        public byte[] RawBytes { get; set; }
    }
}
