using System;

namespace AlarmSystem.Entities
{
    public class Report
    {
        public double Illuminance { get; set; }

        public double Acceleration { get; set; }

        public double Distance { get; set; }

        public bool IsBuzzerOn { get; set; }

        public DateTime TimeStamp { get; set; }

        public byte[] RawBytes { get; set; }
    }
}
