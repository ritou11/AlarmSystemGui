using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmSystem.Entities;

namespace AlarmSystem.DAL
{
    public static class Packer
    {
        public static Report ParseReport(byte[] buffer)
        {
            byte tmp = 0;
            for (var i = 0; i < 7; i++)
                tmp = (byte)(tmp ^ buffer[i]);
            if (tmp != buffer[7])
                return null;

            return
                new Report
                {
                    Distance = BitConverter.ToUInt32(buffer, 1) * 40.0 * 170 / 1000000,
                    Illuminance = buffer[5],
                    IsShaking = buffer[6] == 1,
                    TimeStamp = DateTime.Now
                };
        }
    }
}
